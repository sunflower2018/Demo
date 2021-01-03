using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreAPI.Controllers
{
    [Route("[controller]")]
    public class LogController : Controller
    {
        private readonly Logger logger_nlog;
        private readonly ILog loger_log4net;
        private readonly ILogger<LogController> logger;

        public LogController(ILogger<LogController> logger)
        {
            this.logger = logger;
            this.logger_nlog = NLog.LogManager.GetCurrentClassLogger();
            this.loger_log4net = log4net.LogManager.GetLogger(Startup.Repository.Name, typeof(LogController));
        }
        public string Index()
        {
            //输入【日文件配文件】
            this.logger.LogInformation("write log info success by ilogger");
            this.logger_nlog.Info("write nlog info success by logger_nlog");
            this.loger_log4net.Info("write log4net info success by logger_log4net");
            return "this is log test page";
        }
    }
}
