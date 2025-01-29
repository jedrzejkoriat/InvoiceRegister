using InvoiceRegister.WPF.Base;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.ViewModels
{
	/// <summary>
	/// 
	/// This window handles:
	/// - Creating new invoices
	/// 
	/// </summary>

	public class CreateInvoiceWindowVM : ObservableObject
	{
		private readonly IInvoiceRepository invoiceRepository;
		public CreateInvoiceWindowVM(IServiceProvider serviceProvider)
		{
			this.invoiceRepository = serviceProvider.GetRequiredService<IInvoiceRepository>();
		}

		// Object for handling invoice creation
		private CreateInvoiceVM createInvoiceVM = new CreateInvoiceVM();
		public CreateInvoiceVM CreateInvoiceVM
		{
			get => createInvoiceVM;
			set
			{
				createInvoiceVM = value;
				OnPropertyChanged();
			}
		}

		// Create invoice
		public async Task CreateInvoice()
		{
			await invoiceRepository.CreateInvoiceAsync(CreateInvoiceVM);
		}
	}
}
