using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.MvcWebApp.Controllers
{
    public class LoginCookieController : Controller
    {
        // GET: LoginCookie
        public ActionResult Index()
        {
            string loginName = Request["username"];
            string pwd11 = Request.Form["pwd"];
            if (loginName == "dlz" && pwd11 == "dlz")
            {
                HttpCookie userIdCookie = new HttpCookie("userid", "1");
                userIdCookie.Expires = DateTime.Now.AddMinutes(2);
                HttpCookie userNameCookie = new HttpCookie("username", loginName);
                userNameCookie.Expires = DateTime.Now.AddMinutes(1);
                Response.Cookies.Add(userIdCookie);
                Response.Cookies.Add(userNameCookie);
            }

            HttpCookie ck = Request.Cookies["username"];
            if (ck != null)
                ViewBag.username = ck.Value;

            return View();
        }
        public string TestLogin()
        {
            if (HttpContext.Session == null)
                return "还未登录【Session对象是空的】";
            var session = HttpContext.Session["userid"];
            if (session == null)
                return "还未登录【Session对象中没有存储当前userid的键值对】";
            else
                return "已经登录";
        }
    }
}