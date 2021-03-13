using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreAPI.Controllers
{
    public class StaticFileController : Controller
    {
        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {          
            FileStream fs = new FileStream("备注\\备注.txt", FileMode.Open);
            using (StreamReader sr = new StreamReader(fs))
            {                    
                return Ok(await sr.ReadToEndAsync());
            }         
        }
    }
}
