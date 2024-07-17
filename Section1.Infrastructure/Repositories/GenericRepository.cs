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

        public void Add(T model)
        {
            dbContext.Set<T>().Add(model);
        }

        public void Delete(int id)
        {
            var model = dbContext.Set<T>().Find(id);
            dbContext.Set<T>().Remove(model);
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

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Update(T model)
        {
            dbContext.Set<T>().Update(model);
        }
    }
}
