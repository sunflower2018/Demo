using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreAPI.Controllers
{
    [Route("[controller]")]
    public class ConsoleLogController : Controller
    {
        private readonly ILogger<ConsoleLogController> logger;
        public ConsoleLogController(ILogger<ConsoleLogController> logger)
        {
            this.logger = logger;
        }
        public string Index()
        {
            logger.LogError("write console log success");
            return "this is consolelog test page";
        }
    }
}
