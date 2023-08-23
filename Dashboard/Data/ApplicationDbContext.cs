using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Product> Product { get; set; }
		public DbSet<ProductDetailes> ProductDetails { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Invoice> Invoice { get; set; }
	}
}

