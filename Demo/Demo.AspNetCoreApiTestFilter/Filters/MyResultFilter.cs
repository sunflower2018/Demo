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
    public class MyResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //#region 防盗链  --特别是一些文件，图片信息时

            //string urlReferrer = context.HttpContext.Request.Headers["Referer"];
            //if (string.IsNullOrWhiteSpace(urlReferrer))//直接访问
            //{                   
            //    context.Result = new ForbidResult();                  
            //}             
            //else if (!urlReferrer.Contains("localhost"))//非当前域名             
            //{               
            //    context.Result = new ForbidResult();                
            //}

            //#endregion

            #region 缓存信息

            //从缓存读取信息
            IMemoryCache cache = context.HttpContext.GetService<IMemoryCache>();
          
            //请求路径作为缓存的Key
            string path = context.HttpContext.Request.Path.ToString();
            object value = null;
            if (cache.TryGetValue(path, out value))
            {
                string result = value.ToString();
                context.Result = new ContentResult() { Content = result };
            }

            #endregion
        }
    }
}
