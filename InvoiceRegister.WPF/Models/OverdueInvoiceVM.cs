using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Models
{
	public class OverdueInvoiceVM
	{
		public int Id { get; set; }
		public int ClientId { get; set; }
		public string InvoiceNumber { get; set; }
		public DateTime PaymentDueDate { get; set; }
		public decimal PriceGross { get; set; }
		public string Email {  get; set; }
	}
}
