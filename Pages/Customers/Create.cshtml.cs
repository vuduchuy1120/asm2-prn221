using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment2_17_VuDucHuy.Data;
using Assignment2_17_VuDucHuy.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_17_VuDucHuy.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext _context;

        public CreateModel(Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Customer == null || Customer == null)
          //  {
          //      return Page();
          //  }

            _context.Customer.Add(Customer);
            try
            {
                await _context.SaveChangesAsync();  

            }
            catch(DbUpdateException ex)
            {
                ModelState.AddModelError("Customer.username", "Username already exists");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
