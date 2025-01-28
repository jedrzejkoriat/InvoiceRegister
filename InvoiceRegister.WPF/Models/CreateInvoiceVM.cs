using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Models
{
	public class CreateInvoiceVM
	{
		public string InvoiceNumber { get; set; }
		public string ClientNIP { get; set; }
		public DateTime IssueDate { get; set; } =  DateTime.Now;
		public DateTime SaleDate { get; set; } = DateTime.Now;
		public DateTime PaymentDueDate { get; set; } = DateTime.Now;
	}
}
