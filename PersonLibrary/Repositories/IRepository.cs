using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonLibrary.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int personId);
        void Add(T entity);
        void Update(T Entity);
        IEnumerable<T> GetAsPerCriteria(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetPageWise(int pageNumber, int pageSize);
    }
}
