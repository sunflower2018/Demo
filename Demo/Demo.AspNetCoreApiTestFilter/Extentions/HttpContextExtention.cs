using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreApiTestFilter.Extentions
{
    public static class HttpContextExtention
    {
        public static T GetService<T>(this HttpContext context) where T:class
        {
            return context.RequestServices.GetService(typeof(T)) as T;
        }
        
    }
}
