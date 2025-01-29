using InvoiceRegister.WPF.Base;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.ViewModels
{
	public class InvoiceDetailsWindowVM : ObservableObject
	{
		private int Id;
		private readonly IInvoiceRepository invoiceRepository;
		private readonly IInvoiceItemRepository invoiceItemRepository;
		private readonly IPaymentRepository paymentRepository;
		public InvoiceDetailsWindowVM(IServiceProvider serviceProvider)
		{
			this.invoiceRepository = serviceProvider.GetRequiredService<IInvoiceRepository>();
			this.invoiceItemRepository = serviceProvider.GetRequiredService<IInvoiceItemRepository>();
			this.paymentRepository = serviceProvider.GetRequiredService<IPaymentRepository>();
		}

		private ClientVM clientVM = new ClientVM();
		public ClientVM ClientVM
		{
			get => clientVM;
			set
			{
				clientVM = value;
				OnPropertyChanged();
			}
		}

		private InvoiceVM invoiceVM = new InvoiceVM();
		public InvoiceVM InvoiceVM
		{
			get => invoiceVM;
			set
			{
				invoiceVM = value; 
				OnPropertyChanged();
			}
		}

		private ObservableCollection<InvoiceItemVM> invoiceItemVMs;
		public ObservableCollection<InvoiceItemVM> InvoiceItemVMs
		{
			get => invoiceItemVMs;
			set
			{
				invoiceItemVMs = value;
				OnPropertyChanged();
			}
		}

		private CreateInvoiceItemVM createInvoiceItemVM = new CreateInvoiceItemVM();
		public CreateInvoiceItemVM CreateInvoiceItemVM
		{
			get => createInvoiceItemVM;
			set
			{
				createInvoiceItemVM = value;
				OnPropertyChanged();
			}
		}

		private DateTime newPaymentDate = DateTime.Now;
		public DateTime NewPaymentDate
		{
			get => newPaymentDate;
			set
			{
				newPaymentDate = value;
				OnPropertyChanged();
			}
		}

		public async Task InitializeAsync(int id)
		{
			this.Id = id;
			(InvoiceVM, ClientVM) = await invoiceRepository.GetInvoiceVMAsync(this.Id);
			InvoiceItemVMs = await invoiceItemRepository.GetInvoiceItemVMsAsync(this.Id);
		}

		public async Task RefreshAsync()
		{
			(InvoiceVM, ClientVM) = await invoiceRepository.GetInvoiceVMAsync(this.Id);
			InvoiceItemVMs = await invoiceItemRepository.GetInvoiceItemVMsAsync(this.Id);
		}

		public async Task CreateInvoiceItemAsync()
		{
			await invoiceItemRepository.CreateInvoiceItemAsync(CreateInvoiceItemVM, this.Id);
		}

		public async Task DeleteInvoiceItemAsync(int id)
		{
			await invoiceItemRepository.DeleteInvoiceItemAsync(id);
		}

		public async Task DeleteInvoiceAsync()
		{
			await invoiceRepository.DeleteInvoiceAsync(this.Id);
		}

		public async Task ChangeInvoiceStatusAsync()
		{
			if (await paymentRepository.CreatePaymentAsync(this.Id, NewPaymentDate))
			{
				await invoiceRepository.ChangeStatusAsync(this.Id);
			}
		}
	}
}
