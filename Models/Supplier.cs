using System.ComponentModel.DataAnnotations;

namespace Assignment2_17_VuDucHuy.Models
{
	public class Supplier
	{
		[Key]
		public int supplierId { get; set; }
		public string companyName { get; set; }
		public string address { get; set; }
		public string phone { get; set; }
		public ICollection<Product> Products { get; set; }

	}
}
