using Demo.WebApi.Attributes;
using System.Web;
using System.Web.Mvc;

namespace Demo.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new AppExceptionFilterAttribute()); 会报错
        }
    }
}
