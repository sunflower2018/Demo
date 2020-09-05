/*
 * 1、路由前缀特性只能作用在类上
 * 2、非标方法，如果不显式添加[HttpGet]或[HttpPost]特性，默认采用的是Post
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebApi.Controllers
{
    [RoutePrefix("ccc")]
    public class TestAttrRoutePrefixController : ApiController
    {
        [Route("")]
        public string Test()
        {
            return string.Format("Controller启用了路由前缀");
        }
        [Route("ddd")]
        public string Test1()
        {
            return string.Format("Controller启用了路由前缀，同时action指定了路由名称");
        }
    }
}
