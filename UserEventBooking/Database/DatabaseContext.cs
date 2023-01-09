using Microsoft.EntityFrameworkCore;
using UserEventBooking.Database.Entities;

namespace UserEventBooking.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Booking>? Booking { get; set; }
        public DbSet<Rating>? Rating { get; set; }
        public DbSet<Review>? Review { get; set; }
        public DbSet<Test>? Test { get; set; }
    }
}
