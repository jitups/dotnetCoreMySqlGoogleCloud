using PersonLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonLibrary.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Person entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons;
        }

        public IEnumerable<Person> GetAsPerCriteria(Expression<Func<Person, bool>> predicate)
        {
            return _context.Persons.Where(predicate);
        }

        public Person GetById(int personId)
        {
            return _context.Persons.SingleOrDefault(p => p.PersonId == personId);
        }

        public void Update(Person entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
