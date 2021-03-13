using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreAPI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("[controller]")]
        public string  Index()
        {
            return "错误";
        }
    }
}
