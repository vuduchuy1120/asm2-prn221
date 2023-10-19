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

namespace Assignment2_17_VuDucHuy.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext _context;

        public EditModel(Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer =  await _context.Customer.FirstOrDefaultAsync(m => m.customerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
           

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Customer.username", "Username already exist!");
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(string username)
        {
          return (_context.Customer.Any(e => e.username.ToLower().Trim().Equals(username.ToLower().Trim())));
        }
    }
}
