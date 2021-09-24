using Demo.AspNetCoreApiTestFilter.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.AspNetCoreApiTestFilter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController :  ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("TestExecuteTime")]
        [TimeTestActionFilter]
        public void TestExecuteTime()
        {
            Thread.Sleep(3000);
        }

        [HttpGet]
        [Route("CacheProduct")]
        [CacheProductFilter]
        public List<string> GetProducts()
        {
            return null;
        }

        [HttpGet]
        [Route("TestException")]
        public void TestException()
        {          
            int a = 3, b = 0, c;
            c = a / b;         
        }
        [HttpGet]      
        [Route("TestExceptionFilter")]
        public void TestExceptionFilter()
        {
            int a = 3, b = 0, c;
            c = a / b;
        }
        [HttpPost]
        public string Post(MyCity city)
        {
            return city == null ? "Empty" : city.cname;
        }
        //[HttpPost]
        //public string Test(string id, string name)
        //{
        //    Console.WriteLine(string.Format("{0}|{1}", id, name));
        //    return string.Format("{0}|{1}", id, name);
        //}
    }  
}
