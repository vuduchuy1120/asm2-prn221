using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment2_17_VuDucHuy.Models;

namespace Assignment2_17_VuDucHuy.Data
{
    public class Assignment2_17_VuDucHuyContext : DbContext
    {
        public Assignment2_17_VuDucHuyContext (DbContextOptions<Assignment2_17_VuDucHuyContext> options)
            : base(options)
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.orderId, od.productId });
            //set username as unique
            modelBuilder.Entity<Customer>().HasIndex(c => c.username).IsUnique();
		}

		public DbSet<Assignment2_17_VuDucHuy.Models.Customer> Customer { get; set; } = default!;

		public DbSet<Assignment2_17_VuDucHuy.Models.Product>? Product { get; set; }

		public DbSet<Assignment2_17_VuDucHuy.Models.Order>? Order { get; set; }
    }
}
