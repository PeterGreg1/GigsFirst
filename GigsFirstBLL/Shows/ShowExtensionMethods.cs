using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GigsFirstDAL;
using System.Xml;
using GigsFirstBLL.com.productserve.ticketmaster;
using System.Device.Location;
using System.Data.Spatial;

namespace GigsFirstBLL
{
    public static class ShowExtensionMethods
    {

        public static IQueryable<Show> FilterByLocation(this IQueryable<Show> shows, double latitude, double longitude, double distanceMiles)
        {
            var originPointString = string.Format("POINT({1} {0})",
            latitude.ToString(), longitude.ToString());

            var origin = DbGeography.FromText(originPointString);

            var distanceMeters = distanceMiles * 1609.34d;

            var res = shows.Where(a => a.Venue.Geography.Distance(origin) <= distanceMeters);

            return res;

        }

        public static IQueryable<Show> FilterActiveNotDeletedAndFutureShowsExt(this IQueryable<Show> shows)
        {
            shows = (from s in shows
                     where
                         s.Active == true &&
                         s.Deleted == false &&
                         s.ShowDate >= DateTime.Today
                     select s);
            return shows;
        }
        public static IQueryable<Show> FilterActiveNotDeletedAndPastShowsExt(this IQueryable<Show> shows)
        {
            shows = (from s in shows
                     where
                         s.Active == true &&
                         s.Deleted == false &&
                         s.ShowDate < DateTime.Today
                     select s);
            return shows;
        }

        public static IEnumerable<ImportShow> ImportShows(this XmlReader source)
        {
            while (source.Read())
            {
                source.ReadToFollowing("Show");

                ImportShow show = new ImportShow();

                var ele = source;

                // source.NodeType == XmlNodeType.Text

                if (source.NodeType == XmlNodeType.Element &&
                    source.Name == "Show")
                {
                    try
                    {
                        show.ShowVendorRef = source.GetAttribute("Code");
                        source.ReadToDescendant("Name");
                        show.Name = source.ReadElementContentAsString();
                        source.ReadToFollowing("Artist");
                        show.ArtistName = source.ReadElementContentAsString();
                        // show.Artists.Add(new ImportShowArtist { Name = source.ReadElementContentAsString() });
                        source.ReadToFollowing("Starts");
                        show.ShowDate = DateTimeOffset.Parse(source.ReadElementContentAsString()).UtcDateTime;
                        source.ReadToFollowing("Venue");
                        source.ReadToDescendant("Name");
                        show.VenueName = source.ReadElementContentAsString();
                        source.ReadToFollowing("Town");
                        show.VenueTown = source.ReadElementContentAsString();
                        source.ReadToFollowing("Latitude");
                        show.VenueLat = source.ReadElementContentAsString();
                        source.ReadToFollowing("Longitude");
                        show.VenueLong = source.ReadElementContentAsString();
                        source.ReadToFollowing("Postcode");
                        show.VenuePostcode = source.ReadElementContentAsString();
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine("{0} Exception caught.", e);
                    }

                }
                yield return show;
            }
        }

        public static IEnumerable<ImportShow> ImportShows(this Response source)
        {
            foreach (var tmevent in source.results)
            {
                ImportShow show = new ImportShow();
                show.Name = tmevent.name;
                show.ShowVendorRef = tmevent.eventId.ToString();
                DateTime temp;
                if (DateTime.TryParse(tmevent.eventDate, out temp))
                    show.ShowDate = temp;
                show.VenueName = tmevent.venue.name;
                show.VenueTown = tmevent.venue.city;
                show.VenueVendorID = tmevent.venue.venueId.ToString();
                show.VenuePostcode = tmevent.venue.postcode;
                foreach (var tmartist in tmevent.artists)
                {
                    show.ArtistName = tmartist.name;
                    // show.Artists.Add(new ImportShowArtist { Name = tmartist.name, ArtistVendorID = tmartist.artistId });
                }
                yield return show;
            }
        }

    }
}
