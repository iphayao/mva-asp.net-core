using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMvaWebApp.Models;

namespace SuperMvaWebApp.Controllers
{
    public class TicketsController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            // Go to the database
            var s = new Seat() { Location = "Orchestra", Price = 300.00 };
            return View(s);

        }

        public string Index2()
        {
            return "Hello from Tickets!";
        }
    }
}