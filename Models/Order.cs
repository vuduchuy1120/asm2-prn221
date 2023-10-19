using System.ComponentModel.DataAnnotations;

namespace Assignment2_17_VuDucHuy.Models
{
	public class Order
	{
		[Key]
		public int orderId { get; set; }
		public int customerId { get; set; }
		public DateTime orderDate { get; set; }
		public DateTime requireDate { get; set; }
		public DateTime shippedDate { get; set; }
		public string shipAddress { get; set; }
		//freight
		public decimal freight { get; set; }

		public Customer Customer { get; set; }
		public ICollection<OrderDetail> OrderDetails { get; set; }

	}
}
