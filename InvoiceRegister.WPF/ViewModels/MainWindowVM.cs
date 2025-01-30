using InvoiceRegister.WPF.Base;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Interfaces.Services;
using InvoiceRegister.WPF.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace InvoiceRegister.WPF.ViewModels
{
	/// <summary>
	/// 
	/// This window handles:
	/// - Displaying invoice datagrid
	/// - Filtering invoices
	/// - Sending emails
	/// 
	/// </summary>

	public class MainWindowVM : ObservableObject
	{
		private readonly IInvoiceRepository invoiceRepository;
		private readonly IEmailSenderService emailSenderService;

		public MainWindowVM(IServiceProvider serviceProvider)
		{
			this.invoiceRepository = serviceProvider.GetRequiredService<IInvoiceRepository>();
			this.emailSenderService = serviceProvider.GetRequiredService<IEmailSenderService>();
		}

		// Invoices for datagrid
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

		// Filter data
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

		// Initialize window
		public async Task InitializeAsync()
		{
			InvoiceVMs = await invoiceRepository.GetInvoiceVMsAsync();
		}

		// Refresh invoices and filter
		public async Task RefreshAsync()
		{
			InvoiceVMs = await invoiceRepository.GetInvoiceVMsAsync();
			FilterVM = new FilterVM();
		}

		// Apply filter to datagrid
		public async Task ApplyFilterAsync()
		{
			InvoiceVMs = await invoiceRepository.FilterInvoiceVMsAsync(FilterVM);
		}

		public async Task SendWarningEmailsAsync()
		{
			List<OverdueInvoiceVM> overdueInvoices = await invoiceRepository.GetOverdueInvoiceVMsAsync();
			await emailSenderService.SendWarningEmailsAsync(overdueInvoices);
		}
	}
}
