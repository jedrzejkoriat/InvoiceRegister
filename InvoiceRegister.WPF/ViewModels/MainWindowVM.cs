using InvoiceRegister.WPF.Base;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
namespace InvoiceRegister.WPF.ViewModels
{
	public class MainWindowVM : ObservableObject
	{
		private readonly IClientRepository clientRepository;
		private readonly IInvoiceRepository invoiceRepository;
		private readonly IInvoiceItemRepository invoiceItemRepository;
		private readonly IPaymentRepository paymentRepository;

		public MainWindowVM(IServiceProvider serviceProvider)
		{
			this.clientRepository = serviceProvider.GetRequiredService<IClientRepository>();
			this.invoiceRepository = serviceProvider.GetRequiredService<IInvoiceRepository>();
			this.invoiceItemRepository = serviceProvider.GetRequiredService<IInvoiceItemRepository>();
			this.paymentRepository = serviceProvider.GetRequiredService<IPaymentRepository>();
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
