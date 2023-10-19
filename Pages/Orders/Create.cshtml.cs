using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment2_17_VuDucHuy.Data;
using Assignment2_17_VuDucHuy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2_17_VuDucHuy.Pages.Orders
{
	[Authorize(Policy = "Admin")]
	public class CreateModel : PageModel
    {
        private readonly Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext _context;

        public CreateModel(Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["customerId"] = new SelectList(_context.Customer, "customerId", "customerId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Order == null || Order == null)
          //  {
          //      return Page();
          //  }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Admin");
        }
    }
}
