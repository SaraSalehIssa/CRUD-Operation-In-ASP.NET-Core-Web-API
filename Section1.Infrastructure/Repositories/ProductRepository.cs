using Microsoft.EntityFrameworkCore;
using Section1.Core.Entities;
using Section1.Core.IRepositories;
using Section1.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository (ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Product model)
        {
            dbContext.Products.Add(model);
        }

        public void Delete(int id)
        {
            var model = dbContext.Products.Find(id);
            dbContext.Products.Remove(model);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = dbContext.Products;
            return products;
        }

        public Product GetById(int id)
        {
            return dbContext.Products.Find(id);
        }

        public void Update(Product model)
        {
            dbContext.Products.Update(model);
        }
    }
}
