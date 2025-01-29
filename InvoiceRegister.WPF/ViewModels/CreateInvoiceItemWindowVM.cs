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
	public class CreateInvoiceItemWindowVM : ObservableObject
	{
		private int Id;
		private readonly IClientRepository clientRepository;
		private readonly IInvoiceRepository invoiceRepository;
		public CreateInvoiceItemWindowVM(IServiceProvider serviceProvider)
		{
			this.clientRepository = serviceProvider.GetRequiredService<IClientRepository>();
			this.invoiceRepository = serviceProvider.GetRequiredService<IInvoiceRepository>();
		}

		private ClientVM clientVM;
		public ClientVM ClientVM
		{
			get => clientVM;
			set
			{
				clientVM = value;
				OnPropertyChanged();
			}
		}

		private InvoiceVM invoiceVM;
		public InvoiceVM InvoiceVM
		{
			get => invoiceVM;
			set
			{
				invoiceVM = value; 
				OnPropertyChanged();
			}
		}

		public async Task InitializeAsync(int id)
		{
			this.Id = id;
			(InvoiceVM, ClientVM) = await invoiceRepository.GetInvoiceVMAsync(id);
		}
	}
}
