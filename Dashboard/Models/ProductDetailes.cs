﻿using System.ComponentModel.DataAnnotations;

namespace Dashboard.Models
{
	public class ProductDetailes
	{
		[Key]
		public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
		public string Model { get; set; }
        public int QTY { get; set; }
        public string Color { get; set; }
		public string Image { get; set; }


	}
}