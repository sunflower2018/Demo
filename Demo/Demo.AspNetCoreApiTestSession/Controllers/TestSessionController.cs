/*
 *  1、访问First，只有设置了session,sessionid才会固定下来，否则，即使会话没有结束，每次的sessionid也会不同
 *  2、默认情况下session会存储在cookie中
 */
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Demo.AspNetCoreApiTestSession.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSessionController : ControllerBase
    {
        private static  int i;
        static TestSessionController()
        {
            i= 0;
        }
        [HttpGet]
        public IActionResult First()
        {
            string key = DateTime.Now.ToString("yyyyMMddhhmmss");
            string val = string.Format("sadmin{0}", ++i);
            Response.HttpContext.Session.SetString(key,val);
            var sid = Response.HttpContext.Session.Id;
            return Ok(string.Format("session id is {0}",sid));
        }
        [HttpGet]
        [Route("AsyncFirst")]
        public async Task<IActionResult> AsyncFirst()
        {
            string sid = string.Empty;
            await Task<IActionResult>.Run(() =>
            {
                string key = DateTime.Now.ToString("yyyyMMddhhmmss");
                string val = string.Format("sadmin{0}", ++i);
                Response.HttpContext.Session.SetString(key, val);
                sid = Response.HttpContext.Session.Id;
            });
             return Ok(string.Format("session id is {0}", sid));
            ;

        }
        [HttpGet]
        [Route("second")]
        public IActionResult Second()
        {         
            return Ok(Response.HttpContext.Session);
        }
    }
}
