using Assignment2_17_VuDucHuy.Data;
using Assignment2_17_VuDucHuy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Assignment2_17_VuDucHuy.Pages
{
	public class UserRegister
	{
		[Required(ErrorMessage ="Username must be input value!")]
		public string username { get; set; }
		[Required(ErrorMessage = "Password must be input value!")]
		public string password { get; set; }
		[Required(ErrorMessage = "Fullname must be input value!")]
		public string fullName { get; set; }
		[Required(ErrorMessage = "Address must be input value!")]
		public string address { get; set; }
		[Required(ErrorMessage = "Phone must be input value!")]
		[StringLength(10, MinimumLength = 10)]
		public string phone { get; set; }

	}
	public class RegisterModel : PageModel
	{

		private readonly Assignment2_17_VuDucHuyContext _context;
		public RegisterModel(Assignment2_17_VuDucHuyContext context)
		{
			_context = context;
		}
		[BindProperty]
		public UserRegister UserRegister { get; set; }

		public Customer Customer { get; set; }

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				Customer = new Customer()
				{
					username = UserRegister.username,
					password = UserRegister.password,
					fullName = UserRegister.fullName,
					address = UserRegister.address,
					phone = UserRegister.phone
				};
				_context.Customer.Add(Customer);
				try
				{
					await _context.SaveChangesAsync();
					return RedirectToPage("./Index");
				}
				catch (DbUpdateException ex)
				{
					ModelState.AddModelError("UserRegister.username", "Username already exists");
					return Page();
				}
			}
			return Page();
		}
	}
}
