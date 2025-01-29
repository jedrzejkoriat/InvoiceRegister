using InvoiceRegister.WPF.Base;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace InvoiceRegister.WPF.ViewModels
{
	public class MainWindowVM : ObservableObject
	{
		private readonly IInvoiceRepository invoiceRepository;

		public MainWindowVM(IServiceProvider serviceProvider)
		{
			this.invoiceRepository = serviceProvider.GetRequiredService<IInvoiceRepository>();
			Debug.Write("");
		}

		private ObservableCollection<InvoiceVM> invoiceVMs;
		public ObservableCollection<InvoiceVM> InvoiceVMs
		{
			get => invoiceVMs;
			set
			{
				invoiceVMs = value;
				OnPropertyChanged();
			}
		}

		private FilterVM filterVM = new FilterVM();
		public FilterVM FilterVM
		{
			get => filterVM;
			set
			{
				filterVM = value;
				OnPropertyChanged();
			}
		}

		public async Task InitializeAsync()
		{
			InvoiceVMs = await invoiceRepository.GetInvoiceVMsAsync();
		}

		public async Task ApplyFilterAsync()
		{
			InvoiceVMs = await invoiceRepository.GetFilteredInvoiceVMsAsync(FilterVM);
		}
	}
}
