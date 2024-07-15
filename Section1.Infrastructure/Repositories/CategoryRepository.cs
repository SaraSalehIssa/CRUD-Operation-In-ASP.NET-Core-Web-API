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
    public class CategoryRepository : GenericRepository<Product>, ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Category model)
        {
            throw new NotImplementedException();
        }

        public void Update(Category model)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Category> IGenericRepository<Category>.GetAll()
        {
            throw new NotImplementedException();
        }

        Category IGenericRepository<Category>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
