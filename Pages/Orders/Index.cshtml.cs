using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment2_17_VuDucHuy.Data;
using Assignment2_17_VuDucHuy.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2_17_VuDucHuy.Pages.Orders
{
	[Authorize]
    public class IndexModel : PageModel
    {
        private readonly Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext _context;

        public IndexModel(Assignment2_17_VuDucHuy.Data.Assignment2_17_VuDucHuyContext context)
        {
            _context = context;
        }
        [BindProperty]
        public DateTime? startDate { get; set; }
        [BindProperty]
        public DateTime? endDate { get; set; }

        public IList<Order> Order { get; set; } = default!;

		public async Task OnGetAsync()
		{
			var user = HttpContext.User;
			var username = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (_context.Order != null)
			{
				Order = await _context.Order
				.Include(o => o.Customer)
				.Where(o => o.Customer.username == username)
				.ToListAsync();
			}
		}
		public async Task OnPostAsync()
        {
            if (_context.Order != null)
            {
                if (startDate.HasValue && endDate.HasValue && startDate <= endDate)
                    Order = await _context.Order
                    .Include(o => o.Customer)
                    .Where(o => o.orderDate >= startDate && o.orderDate <= endDate).OrderByDescending(o => o.orderDate)
                    .ToListAsync();
                else if (startDate.HasValue && !endDate.HasValue)
                    Order = await _context.Order
                    .Include(o => o.Customer)
                    .Where(o => o.orderDate >= startDate).OrderByDescending(o => o.orderDate)
                    .ToListAsync();
                else if (!startDate.HasValue && endDate.HasValue)
                    Order = await _context.Order
                    .Include(o => o.Customer)
                    .Where(o => o.orderDate <= endDate).OrderByDescending(o => o.orderDate)
                    .ToListAsync();
                else
                    Order = await _context.Order
                    .Include(o => o.Customer)
                    .ToListAsync();
            }
        }
    }
}
