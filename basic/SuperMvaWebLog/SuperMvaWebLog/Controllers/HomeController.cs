using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SuperMvaWebLog.Controllers
{
    public class HomeController : Controller
    {
        ILogger _log;

        public HomeController(ILogger<HomeController> log)
        {
            _log = log;
        }

        public IActionResult Index()
        {
            _log.LogCritical("SOMETHING BAD");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            _log.LogInformation("We are in About");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
