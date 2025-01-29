using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InvoiceRegister.WPF.Factories
{
	// Window factory to handle creating new windows
	public interface IWindowFactory
	{
		// Create window method - gets the id for the detailsWindow and T parameter
		// Returns object of Window type
		T CreateWindow<T>(int id) where T : Window;
	}
}
