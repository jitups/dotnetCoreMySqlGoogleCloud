using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        Uri baseUrl = new Uri("https://mvcwebapi-215708.appspot.com/");

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public  IEnumerable<PersonViewModel> Persons()
        {
            var persons = new List<PersonViewModel>();
            using (var client = getClient())
            {
                client.BaseAddress = baseUrl;

                var responseMessage = client.GetAsync("api/Person").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    var personsString = responseMessage.Content.ReadAsStringAsync().Result;
                    persons = JsonConvert.DeserializeObject<List<PersonViewModel>>(personsString);
                }
            }
            return persons;
        }

        private static HttpClient getClient()
        {
            return new HttpClient(new HttpClientHandler() { Credentials = new NetworkCredential("webappuser", "Jitu@123") });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
