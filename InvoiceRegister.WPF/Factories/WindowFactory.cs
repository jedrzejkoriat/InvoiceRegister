using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InvoiceRegister.WPF.Factories
{
	public class WindowFactory : IWindowFactory
	{
		private readonly IServiceProvider serviceProvider;
		public WindowFactory(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public T CreateWindow<T>() where T : Window
		{
			var window = serviceProvider.GetRequiredService<T>();
			return window;
		}
	}
}
