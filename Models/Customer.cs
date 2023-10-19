using System.ComponentModel.DataAnnotations;

namespace Assignment2_17_VuDucHuy.Models
{
	public class Customer
	{
		[Key]
		public int customerId { get; set; }
		public string fullName { get; set; }
		public string address { get; set; }
		[StringLength(10, MinimumLength = 10)]
		public string phone { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		// default type = 0
		public int type { get; set; } = 0;

		// not required
		public ICollection<Order> Orders { get; set; }
	}
}
