using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Demo.AspNetCoreAPI.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Demo.AspNetCoreAPI.Controllers
{
    public class LoginController : Controller
    {
        readonly IConfiguration cfg;
        public LoginController(IConfiguration cfg)
        {
            this.cfg = cfg;
        }
        [Route("[controller]")]
        public IActionResult Index(string uname,string pwd)
        {

            JWTConfig jwtconfig = new JWTConfig(); 
            cfg.GetSection("JWT").Bind(jwtconfig);
            var claim = new Claim[]{
            new Claim("UserName", "lb")
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtconfig.IssuerSigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtconfig.Issuer,
                audience: jwtconfig.Audience,
                claims: claim,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });          
        }
    }
}
