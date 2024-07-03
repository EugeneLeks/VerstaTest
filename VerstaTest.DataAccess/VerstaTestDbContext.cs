using Microsoft.EntityFrameworkCore;
using VerstaTest.DataAccess.Entities;

namespace VerstaTest.DataAccess
{
    public class VerstaTestDbContext : DbContext
    {
        public VerstaTestDbContext(DbContextOptions<VerstaTestDbContext> options)
            :base(options) { }

        public DbSet<OrderEntity> Orders { get; set; }

    }
}
