using PersonLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PersonLibrary.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly IDbContext _context;

        public MovieRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Movie entity)
        {
           //  .Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies;
        }

        public IEnumerable<Movie> GetAsPerCriteria(Expression<Func<Movie, bool>> predicate)
        {
            return _context.Movies.Where(predicate);
        }

        public IEnumerable<Movie> GetPageWise(int pageNumber, int pageSize)
        {
            return _context.Movies.Skip(pageNumber * pageSize).Take(pageSize);
        }

        public Movie GetById(int personId)
        {
            return _context.Movies.SingleOrDefault(p => p.MovieId == personId);
        }

        public void Update(Movie entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
