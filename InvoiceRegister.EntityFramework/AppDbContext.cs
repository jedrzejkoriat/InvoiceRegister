using InvoiceRegister.EntityFramework.Configurations;
using InvoiceRegister.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.EntityFramework
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ClientSeedConfiguration());
			modelBuilder.ApplyConfiguration(new CompanyServiceSeedConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		DbSet <Client> Clients { get; set; }
		DbSet<Invoice> Invoices { get; set; }
		DbSet<InvoiceItem> InvoiceItems { get; set; }
		DbSet<Payment> Payments { get; set; }
		DbSet<CompanyService> CompanyServices { get; set; }

	}
}
