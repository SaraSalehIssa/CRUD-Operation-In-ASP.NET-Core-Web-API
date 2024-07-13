using Section1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Core.IRepositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetById(int id);
        public void Add(Product model);
        public void Update(Product model);
        public void Delete(int id);
    }
}
