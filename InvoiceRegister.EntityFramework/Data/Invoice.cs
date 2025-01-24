using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.EntityFramework.Data
{
	public class Invoice
	{
		public int Id { get; set; }
		public int ClientId { get; set; }
		public string InvoiceNumber { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime SaleDate { get; set; }
		public DateTime PaymentDueDate { get; set; }
		public bool IsPaid { get; set; }
	}
}
