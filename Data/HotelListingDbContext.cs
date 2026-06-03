using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Data
{
    //using primary ctor
    //public class HotelListingDbContext(DbContextOptions<HotelListingDbContext> options) : DbContext(options)
    //{
    //}

    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions<HotelListingDbContext> options) : base(options)
        {
            
        }

        //DbSets defines tables to be created
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
