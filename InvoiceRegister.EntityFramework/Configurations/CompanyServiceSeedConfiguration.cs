using InvoiceRegister.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.EntityFramework.Configurations
{
	public class CompanyServiceSeedConfiguration : IEntityTypeConfiguration<CompanyService>
	{
		public void Configure(EntityTypeBuilder<CompanyService> builder)
		{
			builder.HasData(
				new CompanyService { Id = 1, Name = "Service 1", Price = 5000, VAT = 23 },
				new CompanyService { Id = 2, Name = "Service 2", Price = 7000, VAT = 8 },
				new CompanyService { Id = 3, Name = "Service 3", Price = 3500, VAT = 5 },
				new CompanyService { Id = 4, Name = "Service 4", Price = 1500, VAT = 0 },
				new CompanyService { Id = 5, Name = "Service 5", Price = 3000, VAT = 23 }
				);
		}
	}
}
