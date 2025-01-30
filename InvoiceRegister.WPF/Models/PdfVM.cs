using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Models
{
	public class PdfVM
	{
		public InvoiceVM InvoiceVM { get; set; }
		public ClientVM ClientVM { get; set; }
		public List<InvoiceItemVM> IvoiceItemVMs { get; set; }
	}
}
