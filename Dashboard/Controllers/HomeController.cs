using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}
		[Authorize]
		public IActionResult Index()
        {
			var products = _context.Product.ToList();
			return View(products);
        }
		public IActionResult Insert()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateNewProduct(Product product)
		{
			_context.Product.Add(product);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var product = _context.Product.SingleOrDefault(p => p.Id == id);
			if (product != null)
			{
				_context.Product.Remove(product);
				_context.SaveChanges();
			}

			return RedirectToAction("Index");
		}
        public IActionResult Edit(int id)
        {
            var product = _context.Product.SingleOrDefault(p => p.Id == id);

            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
		public IActionResult ProductDetails()
		{
			return View();
		}
		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}