/*
Action Filter ：执行过滤器，一般是在Action执行前后进行过滤。可以通过这个Filter进行一些参数验证逻辑，也可以通过这个filter记录操作日志信息。
它分为执行前，执行后的实现。
执行前（OnActionExecuting）：在Action执行之前。
执行后（OnActionExecuted）：在Action执行完成之后。
需要注意的是：ActionFilter are not supported in Razor Pages.（Action Filter 不支持Razor Pages）
*/
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.AspNetCoreApiTestFilter.Filters
{
    public class TimeTestActionFilter : Attribute, IActionFilter
    {
        private Stopwatch stopwatch;
        private StringBuilder sb;
        public TimeTestActionFilter()
        {
            this.stopwatch = new Stopwatch();
            this.sb = new StringBuilder();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.stopwatch.Stop();
            var dic = context.RouteData.Values;
            this.sb.Append(string.Format("结束执行：{0}, 用时：{1}", this.stopwatch.Elapsed,this.stopwatch.ElapsedMilliseconds));
            Console.WriteLine(this.sb.ToString());

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this.stopwatch.Restart();
            var dic = context.RouteData.Values;
            this.sb.Append(string.Format("控制器：{0}, 方法：{1},开始执行：{2}",dic["controller"],dic["action"],this.stopwatch.Elapsed));
           
        }
    }
}
