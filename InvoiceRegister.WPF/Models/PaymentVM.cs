using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Models
{
	public class PaymentVM
	{
		public int? Id { get; set; }
		public int InvoiceId { get; set; }
		public DateTime PaymentDate { get; set; }
	}
}
