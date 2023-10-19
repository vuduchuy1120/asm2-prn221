using Assignment2_17_VuDucHuy.Data;
using Assignment2_17_VuDucHuy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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

		private List<string> searchBys = new List<string>() { "ID", "ProductName", "Unit Price"};
		[BindProperty]
		public string searchValue { get; set; }
		[BindProperty]
		public string searchBy { get; set; }
		public List<Product> Products { get; set; }

		public string notFound { get; set; } = "";
		public void OnGet()
		{
			Products = _context.Product.ToList();
			ViewData["searchBys"]= new SelectList(searchBys);
		}

		public void OnPost()
		{

			if(searchValue == null)
			{
				Products = _context.Product.ToList();
				
			}
			else
			{
				switch(searchBy)
				{
					case "ID":
						Products = _context.Product.Where(p => p.productID.ToString().Equals(searchValue)).ToList();
						if(Products.Count == 0)
						{
                            notFound = "Not Found";
                        }                   
						break;
					case "ProductName":
						Products = _context.Product.Where(p => p.productName.Contains(searchValue)).ToList();
                        if (Products.Count == 0)
                        {
                            notFound = "Not Found";
                        }
                        break;
					case "Unit Price":
						Products = _context.Product.Where(p => p.unitPrice <= decimal.Parse(searchValue)).ToList();
                        if (Products.Count == 0)
                        {
                            notFound = "Not Found";
                        }
                        break;
				}
			}
			ViewData["searchBys"] = new SelectList(searchBys);
		}
	}
}