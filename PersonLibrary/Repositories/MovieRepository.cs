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
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Movie entity)
        {
            _context.Add(entity);
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
