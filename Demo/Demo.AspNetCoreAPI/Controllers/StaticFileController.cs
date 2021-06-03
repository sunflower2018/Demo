using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreAPI.Controllers
{   
    public class StaticFileController : ControllerBase
    {
        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {          
            FileStream fs = new FileStream("temp.txt", FileMode.Open);           
            using (StreamReader sr = new StreamReader(fs))
            {                    
                return Ok(await sr.ReadToEndAsync());
            }         
        }
        [Route("[controller]/contact")]
        public ActionResult Contact()
        {
            return new ViewResult();
        }

    }
}
