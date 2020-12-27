using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreAPI.Controllers
{
    [Route("[controller]")]
    public class Log4NetController : Controller
    {
        private readonly ILog log;
        
        public Log4NetController()
        {
            this.log = LogManager.GetLogger(Startup.repository.Name, typeof(Log4NetController));
        }
        public string Index()
        {
            log.Info("write log4net info success");
            return "this is log4netlog test page";
        }
    }
}
