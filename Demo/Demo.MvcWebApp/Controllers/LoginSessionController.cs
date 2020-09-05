/*
 * 1、Session产生，
*/
using Demo.MvcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.MvcWebApp.Controllers
{
    public class LoginSessionController : Controller
    {                
        // GET: Login       
        public string Index()
        {
            string ss = HttpContext.Session.SessionID;
            return ss;
        }

        public JsonResult TestSession()
        {           
            HttpContext.Session["userid"] = 1;
            HttpContext.Session["loginName"] = "zhangsan";
            LoginToken token = new LoginToken();
            token.userid = 1;
            token.username = "dlz";
            return Json(token, JsonRequestBehavior.AllowGet);
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