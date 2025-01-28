using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Base.Exceptions
{
	class NIPException : Exception
	{
		public NIPException(string message) : base(message) { }
	}
}
