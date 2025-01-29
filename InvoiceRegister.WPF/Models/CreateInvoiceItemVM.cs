using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Models
{
	public class CreateInvoiceItemVM
	{
		public string Name { get; set; } = "";
		public int Amount { get; set; } = 0;
		public decimal Price { get; set; } = 0;
		public int VAT { get; set; } = 23;
	}
}
