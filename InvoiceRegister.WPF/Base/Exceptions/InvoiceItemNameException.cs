﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Base.Exceptions
{
	// Exception for incorrect invoice item name
	public class InvoiceItemNameException : Exception
	{
		public InvoiceItemNameException(string message) : base(message) { }
	}
}
