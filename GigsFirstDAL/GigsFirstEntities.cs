using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GigsFirstEntities;

namespace GigsFirstDAL
{
    public class GigsFirstDbContext : DbContext
    {

        public GigsFirstDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistAlias> ArtistAliases { get; set; }
        public DbSet<AttendanceType> AttendanceTypes { get; set; }
        public DbSet<ImportShow> ImportShows { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowArtist> ShowArtists { get; set; }
        public DbSet<ShowCategory> ShowCategories { get; set; }
        public DbSet<ShowStatus> ShowStatuses { get; set; }
        public DbSet<ShowVendor> ShowVendors { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserShow> UserShows { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueAlias> VenueAliases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
