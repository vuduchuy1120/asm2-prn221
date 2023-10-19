using System.ComponentModel.DataAnnotations;

namespace Assignment2_17_VuDucHuy.Models
{
	public class Product
	{
		[Key]
		public int productID { get; set; }
		public string productName { get; set; }
		public int supplierId { get; set; }
		public int categoryId { get; set; }
		public string quantityPerUnit { get; set; }
		public decimal unitPrice { get; set; }
		public string productImage { get; set; }

		public Supplier Supplier { get; set; }
		public Category Category { get; set; }

	}
}
