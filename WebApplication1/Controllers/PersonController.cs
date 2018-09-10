using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        IPersonRepository<Person> _personRepository;

        public PersonController(IPersonRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            var persons = _personRepository.GetAll();
            return View(persons);
        }

        public IActionResult Details(int id)
        {
            var person = _personRepository.GetById(id);
            return View(person);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        [ValidateAntiForgeryToken]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepository.Add(person);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

    }
}