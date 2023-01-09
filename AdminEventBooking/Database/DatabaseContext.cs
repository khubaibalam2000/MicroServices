using Microsoft.EntityFrameworkCore;
using AdminEventBooking.Database.Entities;

namespace AdminEventBooking.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Event>? Event { get; set; }
        public DbSet<User>? User { get; set; }
        //public DbSet<Organization>? Organization { get; set; }
        //public DbSet<TicketCategory>? TicketCategory { get; set; }
    }
}
