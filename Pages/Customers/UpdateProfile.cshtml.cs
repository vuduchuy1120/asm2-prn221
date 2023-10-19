using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2_17_VuDucHuy.Data;
using Assignment2_17_VuDucHuy.Models;
using System.Security.Claims;

namespace Assignment2_17_VuDucHuy.Pages.Customers
{
	public class UpdateProfileModel : PageModel
	{
		private readonly Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext _context;

		public UpdateProfileModel(Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext context)
		{
			_context = context;
		}

		[BindProperty]
		public string FullName { get; set; }

		[BindProperty]
		public string Address { get; set; }

		[BindProperty]
		public string Phone { get; set; }

		[BindProperty]
		public string Password { get; set; }
		public string succesMessage { get; set; } = "";
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			var user = HttpContext.User;
			var username = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var customer = await _context.Customer.FirstOrDefaultAsync(m => m.username == username);

			if (customer != null)
			{
				FullName = customer.fullName;
				Address = customer.address;
				Phone = customer.phone;
				Password = customer.password;
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var user = HttpContext.User;
			var username = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var customer = await _context.Customer.FirstOrDefaultAsync(m => m.username == username);

			if (customer != null)
			{
				customer.fullName = FullName;
				customer.address = Address;
				customer.phone = Phone;
				customer.password = Password;
				

				try
				{
					await _context.SaveChangesAsync();
					succesMessage = "Update profile succesfull!";
					//return RedirectToPage("./UpdateProfile");
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}
			}

			return Page();
		}


	}
}
