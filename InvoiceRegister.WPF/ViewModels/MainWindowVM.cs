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

		private bool isBusy = false;
		public async Task InitializeAsync()
		{
			if (isBusy) return;
			isBusy = true;

			try
			{
				InvoiceVMs = await invoiceRepository.GetInvoiceVMsAsync();
			}
			catch { }
			finally { isBusy = false; }
		}
	}
}
