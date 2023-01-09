using Microsoft.EntityFrameworkCore;
using AuthService.Database.Entities;

namespace AuthService.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User>? User { get; set; }
    }
}
