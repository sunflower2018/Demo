/*
ResourceFilter：一般用于对资源型信息进行过滤。常用于防盗链/资源缓存（根据判断缓存中是否存在当前资源，存在则直接返回）。
它分为执行前，执行后的实现。
执行前（OnResourceExecuting）：在Authorization Filter执行完成后。
执行后（OnResourceExecuted）：在Result Execution之后
*/
using Demo.AspNetCoreApiTestFilter.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreApiTestFilter.Filters
{
    public class CacheProductFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var memorycache = context.HttpContext.GetService<IMemoryCache>();
            var products = memorycache.Get("product");
            if ( products== null)
            {
                products = this.GetProducts();
            }
            context.Result = new JsonResult(products);
        }
        private List<string> GetProducts()
        {
            return new List<string> { "apple", "orange", "banana" };
        }
    }
}
