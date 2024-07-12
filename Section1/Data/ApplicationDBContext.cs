using Microsoft.EntityFrameworkCore;
using Section1.Models;

namespace Section1.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        /* Using appsettings.json file
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; Database=APIExample1; Trusted_Connection=true; TrustServerCertificate=true;");
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Description = "This is Laptop" },
                new Product { Id = 2, Name = "Phone", Description = "This is Phone" },
                new Product { Id = 3, Name = "Camera", Description = "This is Camera" }
                );
        }
        public DbSet<Product> Products { get; set; }

    }
}
