using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Core.IRepositories
{
    public interface IUnitOfWork<T> where T: class
    {
        public IProductRepository productRepository { get; set; }
        public ICategoryRepository categoryRepository { get; set; }

        public int Save();
    }
}
