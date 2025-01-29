using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Base.Exceptions
{
	// Exception for incorrect NIP format
	public class InvoiceNIPException : Exception
	{
		public InvoiceNIPException(string message) : base(message) { }
	}
}
