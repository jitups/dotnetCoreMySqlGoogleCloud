using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonLibrary.Entities;
using PersonLibrary.Repositories;
using PersonWebApi.Attributes;

namespace PersonWebApi.Controllers
{
    [BasicAuthorize("*")]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IRepository<Movie> _movieRepository;

        public MovieController(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Movie> movies = _movieRepository.GetAll();
            return Ok(movies);
        }

        [HttpGet]
        [Route(@"GetPagewise/{pageNumber}")]
        public IActionResult GetPagewise(int pageNumber)
        {
            //To avoid cyclic dependency between "Movie" and "UserMovieRatings", set Movie property of UserMovieRatings to null
            //The ToList is needed in order to evaluate the select immediately due to lazy evaluation.
            IEnumerable<Movie> movies = _movieRepository.GetAllQueryable()
                                            .Include("UserMovieRatings")
                                            .Skip((pageNumber - 1) * 10)
                                            .Take(10)
                                            .ToList();
            movies.Select(m => m.UserMovieRatings.Select(umr => umr.Movie = null).ToList()).ToList();
            return Ok(movies);
        }

        [HttpGet]
        [Route(@"GetPagewise/{pageNumber}/{movieName}")]
        public IActionResult SearchPagewise(int pageNumber, string movieName)
        {
            //To avoid cyclic dependency between "Movie" and "UserMovieRatings", set Movie property of UserMovieRatings to null
            //The ToList is needed in order to evaluate the select immediately due to lazy evaluation.
            IEnumerable<Movie> movies = _movieRepository.GetAllQueryable()
                                                .Include("UserMovieRatings")
                                                .Where(m => m.Title.Contains(movieName.Trim()))
                                                .Skip((pageNumber - 1) * 10)
                                                .Take(10)
                                                .ToList();
            movies.Select(m => m.UserMovieRatings.Select(umr => umr.Movie = null).ToList()).ToList();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Movie movie = _movieRepository.GetAllQueryable()
                                        .Include("UserMovieRatings")
                                        .SingleOrDefault(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                //To avoid cyclic dependency between "Movie" and "UserMovieRatings", set Movie property of UserMovieRatings to null
                //The ToList is needed in order to evaluate the select immediately due to lazy evaluation.
                movie.UserMovieRatings.Select(umr => umr.Movie = null).ToList();
            }
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            _movieRepository.Add(movie);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Movie movie)
        {
            _movieRepository.Update(movie);
            return Ok();
        }
    }
}