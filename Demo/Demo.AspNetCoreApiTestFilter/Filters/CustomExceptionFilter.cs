using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreApiTestFilter.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly IWebHostEnvironment env;
        public CustomExceptionFilter(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public void OnException(ExceptionContext context)
        {
            if (this.env.IsDevelopment())//如果是开发环境
            {
                   
            }
            else
            {
                context.Result = new JsonResult(new
                {
                    Result = false,
                    Code = 500,
                    Message = context.Exception.Message
                });
                context.ExceptionHandled = true;//异常已处理
            }

            this.WriteLog(context.Exception);
           
        }

        private void WriteLog(Exception ex)
        {
            //写入日志或数据库
            //。。。。。
        }
    }
}
