using Section1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section1.Core.IRepositories
{
    public interface IGenericRepository<T> where T: class
    {
        public Task<IEnumerable<T>> GetAll();
        public T GetById(int id);
        public void Add(T model);
        public void Update(T model);
        public void Delete(int id);
    }
}
