using Section1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Core.IRepositories
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        public Task<IEnumerable<Product>> GetAllProductsByCategoryId(int CategoryId);
    }
}
