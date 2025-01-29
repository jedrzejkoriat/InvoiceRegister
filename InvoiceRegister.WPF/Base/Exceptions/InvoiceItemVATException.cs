using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Base.Exceptions
{
	// Exception for incorrect VAT number
	public class InvoiceItemVATException : Exception
	{
		public InvoiceItemVATException(string message) : base(message) { }
	}
}
