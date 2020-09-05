/*
 * 1、认证特性必须继承抽象类AuthorizationFilterAttribute
 * 2、当在类上或方法上添加的认证特性，那么请求会先进行认证检查
 * 3、类上添加了认证特性，但方法上添加了允许匿名访问特性,则请求不会被进行认证检查
 */
using Demo.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Demo.WebApi.Controllers
{

    [AuthFilter]
    public class TestAttrAuthFilterController : ApiController
    {        
        public string Get()
        {
            return "hello world";
        }
        [AppExceptionFilter]
        [AllowAnonymous]
        public string Get(int id)
        {            
            throw new Exception("some error happend");           
        }
    }
}
