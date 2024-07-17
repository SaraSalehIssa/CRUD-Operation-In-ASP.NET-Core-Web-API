using Microsoft.EntityFrameworkCore;
using Section1.Core.Entities;
using Section1.Core.IRepositories;
using Section1.Infrastructure.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(T model)
        {
            await dbContext.Set<T>().AddAsync(model);
        }

        public void Delete(int id)
        {
            dbContext.Remove(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            if(typeof(T) == typeof(Product))
            {
                var model = await dbContext.Products.Include(x => x.Category).ToListAsync();
                return (IEnumerable<T>)model;
            }
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T model)
        {
            dbContext.Set<T>().Update(model);
        }
    }
}
