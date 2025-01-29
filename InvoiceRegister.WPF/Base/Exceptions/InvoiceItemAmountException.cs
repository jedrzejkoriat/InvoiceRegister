using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Base.Exceptions
{
	// Exception for incorrect invoice item amount
	public class InvoiceItemAmountException : Exception
	{
		public InvoiceItemAmountException(string message) : base(message) { }
	}
}
