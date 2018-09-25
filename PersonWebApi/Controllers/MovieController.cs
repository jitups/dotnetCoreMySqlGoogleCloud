﻿using System;
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
            var movies = _movieRepository.GetAll();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
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