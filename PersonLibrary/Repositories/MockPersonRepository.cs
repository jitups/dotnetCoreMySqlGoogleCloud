using PersonLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonLibrary.Repositories
{
    public class MockPersonRepository : IRepository<Person>
    {
        private List<Person> _personList = new List<Person>();

        public MockPersonRepository()
        {
            if (_personList.Count == 0)
            {
                _personList.Add(new Person { FirstName = "Jitu", LastName = "Surve", PersonId = 1, DoB = new DateTime(1979, 10, 13) });
                _personList.Add(new Person { FirstName = "Niket", LastName = "Gharat", PersonId = 2, DoB = new DateTime(1989, 10, 5) });
                _personList.Add(new Person { FirstName = "Uttam", LastName = "Vyas", PersonId = 3, DoB = new DateTime(1993, 8, 27) });
                _personList.Add(new Person { FirstName = "Vikas", LastName = "Ranjane", PersonId = 4, DoB = new DateTime(1982, 5, 1) });
            }
        }

        public void Add(Person entity)
        {
            _personList.Add(entity);
        }

        public IEnumerable<Person> GetAll()
        {
            return _personList;
        }

        public IEnumerable<Person> GetAsPerCriteria(Expression<Func<Person, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Person GetById(int personId)
        {
            return _personList.FirstOrDefault(p => p.PersonId == personId);
        }

        public void Update(Person entity)
        { }
    }
}