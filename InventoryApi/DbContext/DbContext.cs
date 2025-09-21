using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options) { }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Representantes> Representantes { get; set; }
    }
}
