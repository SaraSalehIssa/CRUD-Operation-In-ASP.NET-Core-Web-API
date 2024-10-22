﻿using Microsoft.EntityFrameworkCore;
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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository (ApplicationDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryId(int CategoryId)
        {
            // ************  Eager Loading   ************
            // 1 Request
            /*
            var products = await dbContext.Products.Include(x => x.Category)
                .Where(c => c.CategoryId == CategoryId)
                .ToListAsync();
            return products;
            */


            // ************  Explicit Loading    ************
            // 2 Requests: 
            //      1. Original Data
            //      2. Related Data
            /*
            var products = await dbContext.Products.Where(c => c.CategoryId == CategoryId).ToListAsync();
            foreach (var product in products)
            {
                await dbContext.Entry(product).Reference(r => r.Category).LoadAsync();
            }
            return products;
            */


            // ************ Lazy Loading ************

            var products = await dbContext.Products.Where(c => c.CategoryId == CategoryId).ToListAsync();
            return products;
            

        }
    }
}
