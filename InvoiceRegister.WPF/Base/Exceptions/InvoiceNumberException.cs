using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Base.Exceptions
{
	class InvoiceNumberException : Exception
	{
		public InvoiceNumberException(string message) : base(message) { }
	}
}
