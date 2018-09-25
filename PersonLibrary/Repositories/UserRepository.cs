using PersonLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using PersonLibrary.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace PersonLibrary.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetAsPerCriteria(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate);
        }

        public IEnumerable<User> GetPageWise(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public User GetById(int personId)
        {
            return _context.Users.SingleOrDefault(p => p.UserId == personId);
        }

        public void Update(User entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

    }
}
