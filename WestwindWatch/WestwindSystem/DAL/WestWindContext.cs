using Microsoft.EntityFrameworkCore;    // for DbContext, DbContextOptions
using WestwindSystem.Entities;  // for Category

namespace WestwindSystem.DAL
{
    internal class WestwindContext : DbContext
    {
        // for code generation tools
        public WestwindContext()
        {

        }
        // for dependency injections
        public WestwindContext(DbContextOptions<WestwindContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Region> Regions { get; set; } = null!;

        public DbSet<BuildVersion> BuildVersions { get; set; } = null!; 

    }
}
