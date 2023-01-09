using Microsoft.EntityFrameworkCore;
using Test.Database.Entities;

namespace Test.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
