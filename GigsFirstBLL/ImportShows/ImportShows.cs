using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using GigsFirstDAL;
using GigsFirstEntities;

namespace GigsFirstBLL.ImportShows
{
    public interface IShowImporter<out T> where T:ImportShow
    {
        int AddShowsToGf();
        int AddVenues();
        int AddArtists();
        int UpdateVenues();
        int UpdateArtists();
        IEnumerable<T> RetrieveNewShowsFromVendor();
        IQueryable<ImportShow> GetShowsAwaitingImport();
    }

    public abstract class ShowImporter<T> : IShowImporter<T> where T:ImportShow
    {
        protected string Vendor { get; set; }
        protected string Apiurl { get; set; }
        protected int Vendorid { get; set; }
        protected IEnumerable<T>  ImportedShows {get;set;}

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

        public abstract IEnumerable<T> RetrieveNewShowsFromVendor();

        public IQueryable<ImportShow> GetShowsAwaitingImport()
        {
            return _db.ImportShows.OrderBy(a => a.ShowDate).Where(a => a.VendorID == this.Vendorid);
        }

        protected int ExtractNewShows(IEnumerable<T> newshows)
        {
            newshows = newshows.Where(p => !_db.ImportShows.Any(p2 => p2.ShowVendorRef == p.ShowVendorRef && p2.VendorID == this.Vendorid)).ToList();

            var query =
                (from c in newshows
                where !(from o in _db.ShowVendors
                        select o.VendorRefCode)
                .Contains(c.ShowVendorRef)
                select c).ToList();

            foreach (var newshow in query)
            {
                newshow.VendorID = Vendorid;
                newshow.GFArtistID = (from a in _db.ArtistAliases where a.Name == newshow.ArtistName select a.ArtistID).FirstOrDefault();
                newshow.GFVenueID = (from v in _db.VenueAliases where v.Name == newshow.VenueName && (v.Venue.Postcode == newshow.VenuePostcode | v.Venue.Name == newshow.VenueName) select v.VenueID).FirstOrDefault();
                _db.ImportShows.Add(newshow);
            }

            _db.SaveChanges();

            return newshows.Count();
        }

        public int UpdateVenues()
        {
            foreach (var newshow in _db.ImportShows.Where(a => a.VendorID == this.Vendorid && a.GFVenueID == 0).ToList())
            {
                newshow.GFVenueID = _db.VenueAliases.Where(a => a.Name == newshow.VenueName && (a.Venue.Postcode == newshow.VenuePostcode || a.Venue.Name == newshow.VenueName)).Select(a => a.VenueID).FirstOrDefault();
            }

            _db.SaveChanges();

            return 0;
        }

        public int UpdateArtists()
        {
            foreach (var newshow in _db.ImportShows.Where(a => a.VendorID == this.Vendorid && a.GFArtistID == 0).ToList())
            {
                newshow.GFArtistID = _db.ArtistAliases.Where(a => a.Name == newshow.ArtistName).Select(a => a.ArtistID).FirstOrDefault();
            }

            _db.SaveChanges();

            return 0;
        }

        public int AddVenues()
        {      
            var importshows = _db.ImportShows.Where(a => a.GFVenueID == 0 && a.VendorID == this.Vendorid).ToList();
            // this is to check if any have been added previous to the last update
            foreach (var newshow in importshows)
            {
                newshow.GFVenueID = _db.VenueAliases.Where(a => a.Name == newshow.VenueName && (a.Venue.Postcode == newshow.VenuePostcode || a.Venue.Name == newshow.VenueName)).Select(a => a.VenueID).FirstOrDefault();
            }
            _db.SaveChanges();
            importshows = _db.ImportShows.Where(a => a.GFVenueID == 0 && a.VendorID == this.Vendorid).ToList();
            foreach (var dsdsd in importshows)
            {
                var venue = new Venue { Name = dsdsd.VenueName, Postcode = dsdsd.VenuePostcode, Town = dsdsd.VenueTown };
                _db.Venues.Add(venue);
                var alias = new VenueAlias { Name = dsdsd.VenueName, Town = dsdsd.VenueTown, VenueID = venue.VenueID };
                _db.VenueAliases.Add(alias);
                _db.SaveChanges();
            }
            foreach (var newshow in importshows)
            {
                newshow.GFVenueID = (from v in _db.VenueAliases where v.Name == newshow.VenueName && (v.Venue.Postcode == newshow.VenuePostcode | v.Venue.Town == newshow.VenueTown) select v.VenueID).FirstOrDefault();
            }
            _db.SaveChanges();

            return 0;
        }

        public int AddArtists()
        {
            var importshow = _db.ImportShows.Where(a => a.ArtistName != null && a.ArtistName != "" && a.GFArtistID == 0 && a.VendorID == this.Vendorid).ToList();
            // this is to check if any have been added previous to the last update
            foreach (var newshow in importshow)
            {
                newshow.GFArtistID = (from a in _db.ArtistAliases where a.Name == newshow.ArtistName select a.ArtistID).FirstOrDefault();
            }
            _db.SaveChanges();
            importshow = _db.ImportShows.Where(a => a.ArtistName != null && a.ArtistName != "" && a.GFArtistID == 0 && a.VendorID == this.Vendorid).ToList();
            foreach (var dsdsd in importshow)
            {
                var artist = new Artist { Name = dsdsd.ArtistName, Active = true, Deleted = false };
                _db.Artists.Add(artist);
                var alias = new ArtistAlias { Name = dsdsd.ArtistName, ArtistID = artist.ArtistID };
                _db.ArtistAliases.Add(alias);
                _db.SaveChanges();
            }
            foreach (var newshow in importshow)
            {
                newshow.GFArtistID = (from a in _db.ArtistAliases where a.Name == newshow.ArtistName select a.ArtistID).FirstOrDefault();
            }
            _db.SaveChanges();

            return 0;
        }

        public int AddShowsToGf()
        {
            var showstoremove = new List<ImportShow>();

            var showsreadytoimport = _db.ImportShows.Where(a => a.VenueName != null && a.VenueName != "" && a.VendorID == this.Vendorid)
                .Where(a => a.GFArtistID > 0 && a.GFVenueID >  0).ToList();

            foreach (var importshow in showsreadytoimport)
            {
          
                    // check if a show exists on this date at this venue with this artist
                    var exists = _db.Shows.FirstOrDefault(c => c.ShowDate == importshow.ShowDate &&
                                                              c.VenueID == importshow.GFVenueID &&
                                                              c.ShowArtists.Any(z => z.ArtistID == importshow.GFArtistID));

                    if (exists != null)
                    {
                        // we know the show/venue/artist exists, so we need to just add the show vendor
                        var showvendor = new ShowVendor
                        {
                            VendorID = Vendorid,
                            AddedOn = DateTime.Now,
                            VendorRefCode = importshow.ShowVendorRef,
                            ShowID = exists.ShowID
                        };
                        _db.ShowVendors.Add(showvendor);
                        _db.SaveChanges();
                        showstoremove.Add(importshow);
                                     
                        continue;
                    }

                    // check if a show exists on this date at this venue (we now know the artist doesnt exist)
                    exists = _db.Shows.FirstOrDefault(c => c.ShowDate == importshow.ShowDate &&
                                                          c.VenueID == importshow.GFVenueID);

                    if (exists != null)
                    {
                        // we know the show/venue exists, so we need to add the artist & show vendor
                        var showartist = new ShowArtist
                        {
                            ArtistID = importshow.GFArtistID.HasValue ? (int)importshow.GFArtistID : 0,
                            ShowID = exists.ShowID,
                            AddedOn = DateTime.Now
                        };
                        _db.ShowArtists.Add(showartist);

                        var showvendor = new ShowVendor
                        {
                            VendorID = Vendorid,
                            AddedOn = DateTime.Now,
                            VendorRefCode = importshow.ShowVendorRef,
                            ShowID = exists.ShowID
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
                            VenueID = importshow.GFVenueID ?? 0,
                            AddedOn = DateTime.Now,
                            CategoryID = 2,
                            StatusID = 3
                        };
                        _db.Shows.Add(show);

                        var showartist = new ShowArtist
                        {
                            ArtistID = importshow.GFArtistID ?? 0,
                            ShowID = show.ShowID,
                            AddedOn = DateTime.Now
                        };
                        _db.ShowArtists.Add(showartist);

                        var showvendor = new ShowVendor
                        {
                            VendorID = this.Vendorid,
                            AddedOn = DateTime.Now,
                            VendorRefCode = importshow.ShowVendorRef,
                            ShowID = show.ShowID
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
