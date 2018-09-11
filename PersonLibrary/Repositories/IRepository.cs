using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonLibrary.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int personId);
        void Add(T entity);
    }
}
