using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonLibrary.Entities;
using PersonLibrary.Repositories;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        //Uri baseUrl = new Uri("https://mvcwebapi-215708.appspot.com/");
        Uri baseUrl = new Uri("https://localhost:44331");

        //public PersonController(IRepository<Person> personRepository)
        //{
        //    _personRepository = personRepository;
        //}

        public async Task<IActionResult> Index()
        {
            var persons = new List<PersonViewModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseUrl;
                var responseMessage = await client.GetAsync("api/Person");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var personsString = responseMessage.Content.ReadAsStringAsync().Result;
                    persons = JsonConvert.DeserializeObject<List<PersonViewModel>>(personsString);
                }
            }
            return View(persons);
        }

        public async Task<IActionResult> Details(int id)
        {
            PersonViewModel person = await getPersonViewModelById(id);
            return View(person);
        }

        private async Task<PersonViewModel> getPersonViewModelById(int id)
        {
            var person = new PersonViewModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseUrl;
                var responseMessage = await client.GetAsync("api/Person/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var personString = responseMessage.Content.ReadAsStringAsync().Result;
                    person = JsonConvert.DeserializeObject<PersonViewModel>(personString);
                }
            }

            return person;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = baseUrl;
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsJsonAsync("api/Person", person);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            else
            {
                return View();
            }

        }


        public async Task<IActionResult> Update(int id)
        {
            PersonViewModel person = await getPersonViewModelById(id);
            return View(person);
        }

        [HttpPost]
        [ActionName("Update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Person person)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = baseUrl;
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsJsonAsync("api/Person", person);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            else
            {
                return View();
            }

        }

    }
}