/*
 * Chrome无论打开几个浏览器，都是同一次对话？
 * 浏览器访问web服务，web服务写入cookie,后续访问，request中会包含所有cookie
 */
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.AspNetCoreApiTestCookie.Controllers
{
   [ApiController]
   [Route("[controller]")]
    public class TestCookieController : ControllerBase
    {
        private static int i;
        static TestCookieController()
        {
            i = 0;
        }
        [HttpGet]
        public IActionResult AddCookie()
        {
            string key = DateTime.Now.ToString("yyyyMMddhhmmss");
            string val = string.Format("admin{0}", ++i);
            var co = new CookieOptions { Expires = new DateTimeOffset(DateTime.Now.AddMinutes(1))}; //过期时间在当前时间的1分钟后
            Response.Cookies.Append(key,val,co);           
            return Ok(string.Format("添加cookie->key：{0}，value：{1}", key, val));
            
        }
        [HttpGet]
        [Route("ShowRequestCookie")]
        public IActionResult ShowRequestCookie()
        {
            if (Request.Cookies == null || Request.Cookies.Count == 0)
            {
                return Ok("没有cookie");
            }
            return Ok(Request.Cookies);
        }
    }
}
