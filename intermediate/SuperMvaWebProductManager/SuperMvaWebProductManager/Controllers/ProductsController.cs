using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMvaWebProductManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SuperMvaWebProductManager.Controllers
{
    public class ProductsController : Controller
    {
        ProductsContext _context;

        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<ActionResult> Index()
        {
            var products = await _context.Products
                .OrderBy(p => p.Name)
                .ToListAsync();
            return View(products);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await _context.Products.Where(p => p.Id == id).SingleAsync();
            return View(product);
        }

        public async Task<IActionResult> Search(string term)
        {
            var products = await _context.Products
                .FromSql("SELECT * FROM dbo.SearchProducts({0})", term)
                .ToListAsync();
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Description,Price")] Product product)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Products.Add(product);
                await _context.SaveChangesAsync();//RedirectToAction("Index");
                return View(product);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.SingleAsync(p => p.Id == id);
            //ViewData["CategoryId"] = new SelectList(_context.Categories.ToList(), "Id", id.ToString());
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Description,Price")] Product product)
        {
            try
            {
                // TODO: Add update logic here
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return View(product);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}