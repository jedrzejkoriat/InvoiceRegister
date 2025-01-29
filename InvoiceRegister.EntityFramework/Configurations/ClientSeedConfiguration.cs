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
	// Seed configuration for populating clients table
	public class ClientSeedConfiguration : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasData(
				new Client { Id = 1, Name = "Company A", Email = "company_A@localhost.com", City = "Warszawa", Street = "Cybernetyki 5", PostCode = "02-691", NIP = "0123456789" },
				new Client { Id = 2, Name = "Company B", Email = "company_B@localhost.com", City = "Kraków", Street = "Floriańska 12", PostCode = "31-021", NIP = "9876543210" },
				new Client { Id = 3, Name = "Company C", Email = "company_C@localhost.com", City = "Gdańsk", Street = "Długa 32", PostCode = "80-831", NIP = "1234567891" },
				new Client { Id = 4, Name = "Company D", Email = "company_D@localhost.com", City = "Wrocław", Street = "Świdnicka 15", PostCode = "50-066", NIP = "2345678901" },
				new Client { Id = 5, Name = "Company E", Email = "company_E@localhost.com", City = "Poznań", Street = "Półwiejska 20", PostCode = "61-888", NIP = "3456789012" },
				new Client { Id = 6, Name = "Company F", Email = "company_F@localhost.com", City = "Łódź", Street = "Piotrkowska 76", PostCode = "90-009", NIP = "4567890123" },
				new Client { Id = 7, Name = "Company G", Email = "company_G@localhost.com", City = "Katowice", Street = "Stawowa 10", PostCode = "40-095", NIP = "5678901234" },
				new Client { Id = 8, Name = "Company H", Email = "company_H@localhost.com", City = "Lublin", Street = "Krakowskie Przedmieście 5", PostCode = "20-002", NIP = "6789012345" },
				new Client { Id = 9, Name = "Company I", Email = "company_I@localhost.com", City = "Szczecin", Street = "Aleja Niepodległości 4", PostCode = "70-001", NIP = "7890123456" },
				new Client { Id = 10, Name = "Company J", Email = "company_J@localhost.com", City = "Bydgoszcz", Street = "Dworcowa 25", PostCode = "85-009", NIP = "8901234567" }
				);
		}
	}
}
