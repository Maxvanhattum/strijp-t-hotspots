using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Context
{
    public class DBContextApp : DbContext
    {
        public DBContextApp(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Hotspot> Hotspots { get; set; }
        public DbSet<AR360> AR360s { get; set; }
        public DbSet<GeoCoordinates> GeoCoordinates { get; set; }
        public DbSet<MovieInterviewDetails> MovieInterviewDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Business> Businesses { get; set; }
    }
}
