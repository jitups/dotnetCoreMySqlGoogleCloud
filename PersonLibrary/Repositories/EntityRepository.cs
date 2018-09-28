using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PersonLibrary.Repositories
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _dbContext;
        private DbSet<T> _entities;

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _dbContext.Set<T>();

                return _entities;
            }
        }

        public EntityRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return Entities;
        }

        public T GetById(int personId)
        {
            return Entities.Find(personId);
        }

        public void Add(T entity)
        {
            Entities.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            Entities.Update(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetPageWise(int pageNumber, int pageSize)
        {
            return Entities.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<T> GetAsPerCriteria(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate);
        }
    }
}
