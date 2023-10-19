using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment2_17_VuDucHuy.Data;
using Assignment2_17_VuDucHuy.Models;

namespace Assignment2_17_VuDucHuy.Pages.Products
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
        ViewData["categoryId"] = new SelectList(_context.Set<Category>(), "categoryId", "categoryName");
        ViewData["supplierId"] = new SelectList(_context.Set<Supplier>(), "supplierId", "companyName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          //if (!ModelState.IsValid || _context.Product == null || Product == null)
          //  {
          //      return Page();
          //  }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
