using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Models
{
	public class InvoiceItemVM
	{
		public int Id { get; set; }
		public int InvoiceId { get; set; }
		public string Name { get; set; }
		public int Amount { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal VAT { get; set; }
	}
}
