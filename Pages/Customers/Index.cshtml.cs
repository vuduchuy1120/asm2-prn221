﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment2_17_VuDucHuy.Data;
using Assignment2_17_VuDucHuy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2_17_VuDucHuy.Pages.Customers
{
	[Authorize(Policy = "Admin")]
	public class IndexModel : PageModel
    {
        private readonly Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext _context;

        public IndexModel(Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customer != null)
            {
                Customer = await _context.Customer.ToListAsync();
            }
        }
    }
}
