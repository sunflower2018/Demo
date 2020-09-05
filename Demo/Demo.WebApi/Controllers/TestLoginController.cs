using Demo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.ModelBinding;

namespace Demo.WebApi.Controllers
{
    public class TestLoginController : ApiController
    {
        [HttpGet]
        public LoginToken Login(string loginName, string pwd)
        {
            HttpContext.Current.Session["userid"] = 1;
            HttpContext.Current.Session["loginName"] = loginName;
            LoginToken token = new LoginToken();
            token.userid = 1;
            token.username = "dlz";
            return token;
        }
        [HttpGet]      
        public string TestLogin()
        {
            if (HttpContext.Current.Session == null)
                return "还未登录【Session对象是空的】";
            var session = HttpContext.Current.Session["userid"];
            if (session == null)
                return "还未登录【Session对象中没有存储当前userid的键值对】";
            else
                return "已经登录";
        }
       
        //public bool ChangePwd(string oldPwd, string newPwd)
        //{
        //    return true;
        //}
    }
}
