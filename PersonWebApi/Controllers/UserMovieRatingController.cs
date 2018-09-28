using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonLibrary.Entities;
using PersonLibrary.Repositories;
using PersonWebApi.Attributes;

namespace PersonWebApi.Controllers
{
    [BasicAuthorize("*")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMovieRatingController : ControllerBase
    {
        IRepository<UserMovieRatings> _userMovieRatingRepository;

        public UserMovieRatingController(IRepository<UserMovieRatings> movieRepository)
        {
            _userMovieRatingRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UserMovieRatings> movies = _userMovieRatingRepository.GetAll();
            return Ok(movies);
        }

        [HttpGet]
        [Route(@"GetPagewise/{pageNumber}")]
        public IActionResult GetPagewise(int pageNumber)
        {
            IEnumerable<UserMovieRatings> movies = _userMovieRatingRepository.GetPageWise(pageNumber, 10);
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UserMovieRatings userMovieRatings = _userMovieRatingRepository.GetById(id);
            if (userMovieRatings == null)
            {
                return NotFound();
            }
            return Ok(userMovieRatings);
        }

        [HttpPost]
        public IActionResult Post(UserMovieRatings userMovieRatings)
        {
            _userMovieRatingRepository.Add(userMovieRatings);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(UserMovieRatings userMovieRatings)
        {
            _userMovieRatingRepository.Update(userMovieRatings);
            return Ok();
        }
    }
}