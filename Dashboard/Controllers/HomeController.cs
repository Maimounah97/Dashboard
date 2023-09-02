using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
			var Name = HttpContext.User.Identity.Name;
			CookieOptions options = new CookieOptions();
			options.Expires = DateTime.Now.AddMinutes(10);
			Response.Cookies.Append("Name", Name, options);
			ViewBag.Name = Name;
			var products = _context.Product.ToList();
			return View(products);
        }
		[HttpPost]
		public IActionResult Index(string ProductName)
		{
			var is_search = 0;
			var products = _context.Product.Where(x => x.ProductName.Contains(ProductName)).ToList();
			is_search = 1;
			ViewBag.is_search = is_search;
			ViewBag.Products = products;
			return View(products);
		}
		//[HttpPost]
		//public IActionResult Search(string Description)
		//{
		//	var is_search = 0;
		//	var ProductDetails = _context.ProductDetails.Where(x => x.Description.Contains(Description)).ToList();
		//	is_search = 1;
		//	ViewBag.is_search = is_search;
		//	ViewBag.ProductDetails = ProductDetails;
		//	return RedirectToAction("ProductDetails");
		//}
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
        public IActionResult EditProductDetails(int id)
        {
            var ProductDetails = _context.ProductDetails.SingleOrDefault(p => p.Id == id);
			var Products = _context.Product.ToList();
			ViewBag.Products = Products;
			return View(ProductDetails);
        }
        [HttpPost]
        public IActionResult UpdateProductDetails(ProductDetailes productDetails)
        {
            _context.ProductDetails.Update(productDetails);
            _context.SaveChanges();
            return RedirectToAction("ProductDetails");
        }
		public IActionResult DeleteProductDetails(int id)
		{
			var ProductDetails = _context.ProductDetails.SingleOrDefault(p => p.Id == id);
			if (ProductDetails != null)
			{
				_context.ProductDetails.Remove(ProductDetails);
				_context.SaveChanges();
			}

			return RedirectToAction("ProductDetails");
		}
		public IActionResult ProductDetails()
		{
			var Products = _context.Product.ToList();
			var ProductDetails = _context.ProductDetails.ToList();
			ViewBag.Name = Request.Cookies["Name"];
			ViewBag.ProductDetails = ProductDetails;
			return View(Products);
		}
		[HttpPost]
		public IActionResult ProductDetails(string ProductName)
		{
			var is_search = 0;
			var Products = _context.Product.Where(x => x.ProductName.Contains(ProductName)).ToList();
			var ProductDetails = _context.ProductDetails.ToList();
			is_search = 1;
			ViewBag.is_search = is_search;
			ViewBag.Name = Request.Cookies["Name"];
			ViewBag.ProductDetails = ProductDetails;
			return View(Products);
		}
		public IActionResult AddProductDetails(ProductDetailes ProductDetails)
		{
			_context.ProductDetails.Add(ProductDetails);
			_context.SaveChanges();
			return RedirectToAction("ProductDetails");
		}
		public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Customers()
        {
            return View();
        }
        public IActionResult Invoices()
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