﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreAPI.Controllers
{
    [Route("[controller]")]
    public class TestViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
