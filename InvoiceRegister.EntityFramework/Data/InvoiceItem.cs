using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.EntityFramework.Data
{
	public class InvoiceItem
	{
		public int Id { get; set; }
		public int InvoiceId { get; set; }
		public string Name { get; set; }
		public int Amount { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal VAT { get; set; }
	}
}
