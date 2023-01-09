using Microsoft.EntityFrameworkCore;
using ApiGateway.Database.Entities;

namespace ApiGateway.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User>? User { get; set; }
    }
}
