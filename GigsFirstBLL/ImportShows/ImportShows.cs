using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using GigsFirstDAL;
using GigsFirstEntities;

namespace GigsFirstBLL.ImportShows
{
    public interface IShowImporter
    {
        int AddShowsToGf();
        int AddVenues();
        int AddArtists();
        int UpdateVenues();
        int UpdateArtists();
        IEnumerable<ImportShow> RetrieveNewShowsFromVendor();
        IQueryable<ImportShow> GetShowsAwaitingImport();
        void MapImportShows();
    }

    public abstract class ShowImporter
    {
        protected string Vendor { get; set; }
        protected string Apiurl { get; set; }
        protected int Vendorid { get; set; }
        protected IEnumerable<ImportShow>  ImportedShows {get;set;}

        private int _retrieveamount = 1000;
        public int RetrieveAmount
        {
            get { return _retrieveamount; }
            set { _retrieveamount = value; }
        }

        private readonly GigsFirstDbContext _db = new GigsFirstDbContext();

        public void RetrieveNewShows()
        {
            ImportedShows = RetrieveNewShowsFromVendor();
            ExtractNewShows(ImportedShows);
        }

        public abstract IEnumerable<ImportShow> RetrieveNewShowsFromVendor();

        public IQueryable<ImportShow> GetShowsAwaitingImport()
        {
            return _db.ImportShows.OrderBy(a => a.ShowDate).Where(a => a.VendorId == this.Vendorid);
        }

        protected int ExtractNewShows(IEnumerable<ImportShow> newshows)
        {
            newshows = newshows.Where(p => !_db.ImportShows.Any(p2 => p2.ShowVendorRef == p.ShowVendorRef && p2.VendorId == this.Vendorid)).ToList();

            var query =
                (from c in newshows
                where !(from o in _db.ShowVendors
                        select o.VendorRefCode)
                .Contains(c.ShowVendorRef)
                select c).ToList();

            foreach (var newshow in query)
            {
                newshow.VendorId = Vendorid;
                _db.ImportShows.Add(newshow);
            }

            _db.SaveChanges();

            return newshows.Count();
        }

        public void MapImportShows()
        {
            foreach (var importShow in _db.ImportShows)
            {
                importShow.VendorId = Vendorid;
                importShow.GfArtistId = _db.ArtistAliases.Where(a => a.Name == importShow.ArtistName && importShow.GfArtistId == 0).Select(a => a.ArtistId).FirstOrDefault();
                importShow.GfVenueId =
                    _db.VenueAliases.Where(
                        a => importShow.GfVenueId == 0 && 
                            a.Name == importShow.ArtistName &&
                            (a.Venue.Postcode == importShow.VenuePostcode | a.Venue.Name == importShow.VenueName))
                        .Select(a => a.VenueId)
                        .FirstOrDefault();
                //importShow.GfShowId = _db.Shows.Where(a => a.ShowDate == show.ShowDate && a.VenueId == show.GfVenueId && a.ShowArtists.Select(b => b.ArtistId).Contains(show.GfArtistId));
                _db.ImportShows.Add(importShow);
            }

        }

        public int UpdateVenues()
        {
            _db.Database.ExecuteSqlCommand("UPDATE ImportShows SET GFVenueID = (SELECT TOP 1 VenueID FROM VenueAliases WHERE VenueAliases.Name = ImportShows.VenueName) WHERE ImportShows.GFVenueID = 0 OR ImportShows.GFVenueID IS NULL");
            return 0;
        }

        public int UpdateArtists()
        {
            _db.Database.ExecuteSqlCommand("UPDATE ImportShows SET GFArtistID = (SELECT TOP 1 ArtistID FROM ArtistAliases WHERE ArtistAliases.Name = ImportShows.ArtistName) WHERE ImportShows.GFArtistID = 0 OR ImportShows.GFVenueID IS NULL");
            return 0;
        }

        public int AddVenues()
        {
            UpdateVenues();
            var importshows = _db.ImportShows.Where(a => a.GfVenueId == 0 && a.VendorId == this.Vendorid).ToList();
            foreach (var importshow in importshows)
            {
                var venue = new Venue { Name = importshow.VenueName, Postcode = importshow.VenuePostcode, Town = importshow.VenueTown };
                _db.Venues.Add(venue);
                var alias = new VenueAlias { Name = importshow.VenueName, Town = importshow.VenueTown, VenueId = venue.VenueId };
                _db.VenueAliases.Add(alias);
                _db.SaveChanges();
            }
            foreach (var newshow in importshows)
            {
                newshow.GfVenueId = (from v in _db.VenueAliases where v.Name == newshow.VenueName && (v.Venue.Postcode == newshow.VenuePostcode | v.Venue.Town == newshow.VenueTown) select v.VenueId).FirstOrDefault();
            }
            _db.SaveChanges();

            return 0;
        }

        public int AddArtists()
        {
            // this is to check if any have been added previous to the last update
            UpdateArtists();

            var importshows = _db.ImportShows.Where(a => a.ArtistName != null && a.ArtistName != "" && a.GfArtistId == 0 && a.VendorId == this.Vendorid).ToList();
            foreach (var importshow in importshows)
            {
                var artist = new Artist { Name = importshow.ArtistName, Active = true, Deleted = false };
                _db.Artists.Add(artist);
                var alias = new ArtistAlias { Name = importshow.ArtistName, ArtistId = artist.ArtistId };
                _db.ArtistAliases.Add(alias);
                _db.SaveChanges();
            }
            foreach (var newshow in importshows)
            {
                newshow.GfArtistId = (from a in _db.ArtistAliases where a.Name == newshow.ArtistName select a.ArtistId).FirstOrDefault();
            }
            _db.SaveChanges();

            return 0;
        }

        public int AddShowsToGf()
        {
            var showstoremove = new List<ImportShow>();

            var showsreadytoimport = _db.ImportShows.Where(a => a.VenueName != null && a.VenueName != "" && a.VendorId == this.Vendorid)
                .Where(a => a.GfArtistId > 0 && a.GfVenueId >  0).ToList();

            foreach (var importshow in showsreadytoimport)
            {
          
                    // check if a show exists on this date at this venue with this artist
                    var exists = _db.Shows.FirstOrDefault(c => c.ShowDate == importshow.ShowDate &&
                                                              c.VenueId == importshow.GfVenueId &&
                                                              c.ShowArtists.Any(z => z.ArtistId == importshow.GfArtistId));

                    if (exists != null)
                    {
                        // we know the show/venue/artist exists, so we need to just add the show vendor
                        var showvendor = new ShowVendor
                        {
                            VendorId = Vendorid,
                            AddedOn = DateTime.Now,
                            VendorRefCode = importshow.ShowVendorRef,
                            ShowId = exists.ShowId
                        };
                        _db.ShowVendors.Add(showvendor);
                        _db.SaveChanges();
                        showstoremove.Add(importshow);
                                     
                        continue;
                    }

                    // check if a show exists on this date at this venue (we now know the artist doesnt exist)
                    exists = _db.Shows.FirstOrDefault(c => c.ShowDate == importshow.ShowDate &&
                                                          c.VenueId == importshow.GfVenueId);

                    if (exists != null)
                    {
                        // we know the show/venue exists, so we need to add the artist & show vendor
                        var showartist = new ShowArtist
                        {
                            ArtistId = importshow.GfArtistId.HasValue ? (int)importshow.GfArtistId : 0,
                            ShowId = exists.ShowId,
                            AddedOn = DateTime.Now
                        };
                        _db.ShowArtists.Add(showartist);

                        var showvendor = new ShowVendor
                        {
                            VendorId = Vendorid,
                            AddedOn = DateTime.Now,
                            VendorRefCode = importshow.ShowVendorRef,
                            ShowId = exists.ShowId
                        };
                        _db.ShowVendors.Add(showvendor);
                     
                        _db.SaveChanges();
                        showstoremove.Add(importshow);
                        
                        continue;
                    }

                    // we now know the show doesnt exist in any context on the website, so lets add it as a completely
                    // new show
                    if (exists == null)
                    {
                        var show = new Show
                        {
                            Name = importshow.Name,
                            ShowDate = importshow.ShowDate,
                            VenueId = importshow.GfVenueId ?? 0,
                            AddedOn = DateTime.Now,
                            CategoryId = 2,
                            StatusId = 3
                        };
                        _db.Shows.Add(show);

                        var showartist = new ShowArtist
                        {
                            ArtistId = importshow.GfArtistId ?? 0,
                            ShowId = show.ShowId,
                            AddedOn = DateTime.Now
                        };
                        _db.ShowArtists.Add(showartist);

                        var showvendor = new ShowVendor
                        {
                            VendorId = this.Vendorid,
                            AddedOn = DateTime.Now,
                            VendorRefCode = importshow.ShowVendorRef,
                            ShowId = show.ShowId
                        };
                        _db.ShowVendors.Add(showvendor);

                        try
                        {
                            // Your code...
                            // Could also be before try if you know the exception occurs in SaveChanges

                            _db.SaveChanges();
                        }
                        catch (DbEntityValidationException e)
                        {
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                        ve.PropertyName, ve.ErrorMessage);
                                }
                                
                            }
                            throw;
                        }

                       
                        showstoremove.Add(importshow);
      
                }
            }

            foreach (var show in showstoremove)
            {
                _db.ImportShows.Remove(show);
            }

            _db.SaveChanges();

            return 0;
        }
    }
}
