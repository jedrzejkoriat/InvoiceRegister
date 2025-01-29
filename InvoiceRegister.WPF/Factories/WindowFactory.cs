using InvoiceRegister.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InvoiceRegister.WPF.Factories
{
	// Window factory to handle creating new windows
	public class WindowFactory : IWindowFactory
	{
		private readonly IServiceProvider serviceProvider;
		public WindowFactory(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		// Create window method - gets the id for the detailsWindow and T parameter
		// Returns object of Window type
		public T CreateWindow<T>(int id) where T : Window
		{
			// Pass required dependencies to window
			var window = serviceProvider.GetRequiredService<T>();

			// Passing the InvoiceId for the detailsWindow
			if (window is InvoiceDetailsWindow detailsWindow)
			{
				detailsWindow.InvoiceId = id;
			}

			return window;
		}
	}
}
