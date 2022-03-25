using Microsoft.EntityFrameworkCore;    // for DbContext, DbContextOptions, DbSet
using WestWindSystem.Entities;  // for Category, Product

namespace WestWindSystem.DAL
{
    // Step 1: inherit from DbContext
    internal class WestWindContext : DbContext
    {
        // Step 2: create a greedy constructor with parameter for DbContextOptions
        // and pass the DbContextOptions parameter to the constructor of DbContext 
        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }

        // Step 3: Create a DbSet property for each entity
        public DbSet<Category> Categories { get;set; }
        public DbSet<Product> Products { get;set; }

    }
}
