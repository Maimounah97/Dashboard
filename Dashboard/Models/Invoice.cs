namespace Dashboard.Models
{
	public class Invoice
	{
		public int Id { get; set; }
		public int CustumerId { get; set; }
		public int ProductId { get; set; }
		public double Price { get; set; }
		public int QTY { get; set; }
		public float Tax { get; set; }
		public float Descount { get; set; }
		public double Total { get; set; }

	}
}
