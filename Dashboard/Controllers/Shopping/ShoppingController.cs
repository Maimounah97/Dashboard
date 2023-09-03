using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using MimeKit;
using MailKit.Net.Smtp;
using Dashboard.Data;

namespace Dashboard.Controllers.Shopping
{
	public class ShoppingController : Controller
	{
        private readonly ILogger<ShoppingController> _logger;
        private readonly ApplicationDbContext _context;

        public ShoppingController(ILogger<ShoppingController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
		{
            var Products = _context.Product.ToList();
            var ProductDetails = _context.ProductDetails.ToList();
            ViewBag.Name = Request.Cookies["Name"];
            ViewBag.ProductDetails = ProductDetails;
            return View(Products);
		}
        public IActionResult ProductDetails(int id, int productId)
        {
            var product = _context.Product.SingleOrDefault(p => p.Id == productId);
            var ProductDetails = _context.ProductDetails.SingleOrDefault(pd => pd.Id == id);
            var ProductDetailsList = _context.ProductDetails.ToList();
            ViewBag.ProductDetails = ProductDetails;
            ViewBag.ProductDetailsList = ProductDetailsList;
            ViewBag.Product = product;
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        //public async Task<string> SendMail()
        //{
        //	//xxoiqetkzpzyuxzc
        //	//nzufhzxvbmvqyves

        //	var message = new MimeMessage();
        //	message.From.Add(new MailboxAddress("TestMessage", "h.maimounah@gmail.com"));
        //	message.To.Add(MailboxAddress.Parse("maealhejaili@gmail.com"));
        //	message.Subject = "test email from asp.net ";
        //	message.Body = new TextPart("plain")
        //	{
        //		Text = "Welcom"
        //	};
        //	using (var client = new SmtpClient())
        //	{
        //		try
        //		{
        //			client.Connect("smtp.gmail.com", 587);
        //			client.Authenticate("tuwiqst@gmail.com", "nzufhzxvbmvqyves");
        //			await client.SendAsync(message);
        //			client.Disconnect(true);

        //		}
        //		catch (Exception e)
        //		{
        //			Console.WriteLine(e.Message.ToString());
        //		}



        //	};

        //	return "ok";
        //}
    }
}
