using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMvaWepApi.Models;

namespace SuperMvaWepApi.Controllers
{
    [Produces("application/xml")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product>(new[] {
            new Product() { ID = 1, Name = "Green Peppers"},
            new Product() { ID = 2, Name = "Soft Taco"},
            new Product() { ID = 3, Name = "Chipotle Sauce"}
         });

        [HttpGet]
        public List<Product> Get()
        {
            return _products; //pretend to go to the database
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _products.SingleOrDefault(p => p.ID == id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.ID }, product);
        }
    }
}