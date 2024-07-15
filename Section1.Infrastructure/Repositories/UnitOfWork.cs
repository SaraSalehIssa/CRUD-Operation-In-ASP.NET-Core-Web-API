using Section1.Core.IRepositories;
using Section1.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Infrastructure.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            productRepository = new ProductRepository(dbContext);
        }

        public IProductRepository productRepository { get; set; }
        public ICategoryRepository categoryRepository { get; set; }

        public int Save() => dbContext.SaveChanges();
        
    }
}
