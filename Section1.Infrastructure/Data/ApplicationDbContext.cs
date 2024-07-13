using Microsoft.EntityFrameworkCore;
using Section1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>().HasKey(x => new {x.Id, x.ProductId, x.OrderId});

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets" },
                new Category { Id = 2, Name = "Books", Description = "Books and literature" },
                new Category { Id = 3, Name = "Clothing", Description = "Apparel and accessories" }
);

            modelBuilder.Entity<LocalUser>().HasData(
                new LocalUser { Id = 1, Name = "Ahmed Haggag", Username = "Haggag281", Password = "password123", Role = "Admin" },
                new LocalUser { Id = 2, Name = "Tarek Sharim", Username = "Tarek777", Password = "password456", Role = "User" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Smartphone", Price = 299.99m, Image = "smartphone.jpg", CategoryId = 1 },
                new Product { Id = 2, Name = "Laptop", Price = 799.99m, Image = "laptop.jpg", CategoryId = 1 },
                new Product { Id = 3, Name = "Novel", Price = 19.99m, Image = "novel.jpg", CategoryId = 2 },
                new Product { Id = 4, Name = "T-Shirt", Price = 9.99m, Image = "tshirt.jpg", CategoryId = 3 },
                new Product { Id = 5, Name = "Jeans", Price = 49.99m, Image = "jeans.jpg", CategoryId = 3 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Status = "Pending", Date = new DateTime(2023, 12, 11), LocalUserId = 1 },
                new Order { Id = 2, Status = "Completed", Date = new DateTime(2023, 12, 12), LocalUserId = 2 },
                new Order { Id = 3, Status = "Shipped", Date = new DateTime(2023, 12, 13), LocalUserId = 1 }
            );

            modelBuilder.Entity<OrderDetails>().HasData(
                new OrderDetails { Id = 1, OrderId = 1, ProductId = 1, Price = 299.99m, Quantity = 1 },
                new OrderDetails { Id = 2, OrderId = 1, ProductId = 4, Price = 9.99m, Quantity = 2 },
                new OrderDetails { Id = 3, OrderId = 2, ProductId = 3, Price = 19.99m, Quantity = 1 },
                new OrderDetails { Id = 4, OrderId = 3, ProductId = 2, Price = 799.99m, Quantity = 1 },
                new OrderDetails { Id = 5, OrderId = 3, ProductId = 5, Price = 9.99m, Quantity = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }
    }
}
