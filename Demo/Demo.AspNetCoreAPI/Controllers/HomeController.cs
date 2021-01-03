using Demo.AspNetCoreAPI.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demo.AspNetCoreAPI.Controllers
{
    public class HomeController : Controller
    {
        [Route("[controller]")]
        [Authorize]
        public IActionResult Index()
        {                            
            return BadRequest(new { message = "username or password is incorrect." });          
        }
    }
}
