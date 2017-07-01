using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperMvaWebApp.Controllers
{
    public class ScottIndexViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class ScottController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            var vm = new ScottIndexViewModel() { Age = 29, Name = "Scott" };
            return View(vm);
        }
    }
}
