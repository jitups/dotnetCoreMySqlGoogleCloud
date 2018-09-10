using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PersonRepository : IPersonRepository<Person>
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

        public Person GetById(int personId)
        {
            return _context.Persons.SingleOrDefault(p => p.PersonId == personId);
        }
    }
}
