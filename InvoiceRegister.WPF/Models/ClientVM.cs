using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Models
{
	public class ClientVM
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Street { get; set; }
		public string PostCode { get; set; }
		public string City { get; set; }
		public string NIP { get; set; }
	}
}
