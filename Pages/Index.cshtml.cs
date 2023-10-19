using Assignment2_17_VuDucHuy.Data;
using Assignment2_17_VuDucHuy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment2_17_VuDucHuy.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly Assignment2_17_VuDucHuyContext _context;
		public IndexModel(ILogger<IndexModel> logger, Assignment2_17_VuDucHuyContext context)
		{
			_logger = logger;
			_context = context;
		}


		public List<Product> Products { get; set; }


		public void OnGet()
		{
			Products = _context.Product.ToList();
		}
	}
}