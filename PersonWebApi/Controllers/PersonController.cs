using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonLibrary.Entities;
using PersonLibrary.Repositories;

namespace PersonWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonRepository<Person> _personRepository;

        public PersonController(IPersonRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personRepository.GetAll();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personRepository.GetById(id);
            if(person==null)
            {
                return NotFound();
            }
            return Ok(person);
        }
    }
}