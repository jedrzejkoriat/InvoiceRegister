using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Models
{
	public class InvoiceVM
	{
		// Invoice table data
		public int? Id { get; set; }
		public int ClientId { get; set; }
		public string InvoiceNumber { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime SaleDate { get; set; }
		public DateTime PaymentDueDate { get; set; }
		public bool IsPaid { get; set; }

		// Payment table data
		public DateTime? PaymentDate { get; set; }

		// InvoiceItem table data
		public decimal PriceGross { get; set; }
		public decimal ValueNet { get; set; }
		public decimal ValueVAT { get; set; }

		// Client table data
		public string ClientName { get; set; }
		public string ClientNIP { get; set; }

	}
}
