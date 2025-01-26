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
	public class ClientSeedConfiguration : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasData(
				new Client { Id = 1, Name = "Firma A", City = "Warszawa", Street = "Cybernetyki 5", PostCode = "02-691", NIP = "0123456789" },
				new Client { Id = 2, Name = "Firma B", City = "Kraków", Street = "Floriańska 12", PostCode = "31-021", NIP = "9876543210" },
				new Client { Id = 3, Name = "Firma C", City = "Gdańsk", Street = "Długa 32", PostCode = "80-831", NIP = "1234567891" },
				new Client { Id = 4, Name = "Firma D", City = "Wrocław", Street = "Świdnicka 15", PostCode = "50-066", NIP = "2345678901" },
				new Client { Id = 5, Name = "Firma E", City = "Poznań", Street = "Półwiejska 20", PostCode = "61-888", NIP = "3456789012" },
				new Client { Id = 6, Name = "Firma F", City = "Łódź", Street = "Piotrkowska 76", PostCode = "90-009", NIP = "4567890123" },
				new Client { Id = 7, Name = "Firma G", City = "Katowice", Street = "Stawowa 10", PostCode = "40-095", NIP = "5678901234" },
				new Client { Id = 8, Name = "Firma H", City = "Lublin", Street = "Krakowskie Przedmieście 5", PostCode = "20-002", NIP = "6789012345" },
				new Client { Id = 9, Name = "Firma I", City = "Szczecin", Street = "Aleja Niepodległości 4", PostCode = "70-001", NIP = "7890123456" },
				new Client { Id = 10, Name = "Firma J", City = "Bydgoszcz", Street = "Dworcowa 25", PostCode = "85-009", NIP = "8901234567" }
				);
		}
	}
}
