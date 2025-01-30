using InvoiceRegister.WPF.Base;
using InvoiceRegister.WPF.Base.Exceptions;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Interfaces.Services;
using InvoiceRegister.WPF.Models;
using Microsoft.Extensions.DependencyInjection;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.ViewModels
{
	/// <summary>
	/// 
	/// This window handles:
	/// - Displaying invoice items data grid
	/// - Deleting invoice items
	/// - Creating invoice items
	/// - Deleting invoices
	/// - Changing invoice payment status + Creating payment entities
	/// - Generating invoice files
	/// 
	/// </summary>

	public class InvoiceDetailsWindowVM : ObservableObject
	{
		// InvoiceId for initialization
		private int InvoiceId;

		private readonly IInvoiceRepository invoiceRepository;
		private readonly IInvoiceItemRepository invoiceItemRepository;
		private readonly IPaymentRepository paymentRepository;
		private readonly IClientRepository clientRepository;
		private readonly IPdfService pdfService;

		public InvoiceDetailsWindowVM(IServiceProvider serviceProvider)
		{
			this.invoiceRepository = serviceProvider.GetRequiredService<IInvoiceRepository>();
			this.invoiceItemRepository = serviceProvider.GetRequiredService<IInvoiceItemRepository>();
			this.paymentRepository = serviceProvider.GetRequiredService<IPaymentRepository>();
			this.clientRepository = serviceProvider.GetRequiredService<IClientRepository>();
			this.pdfService = serviceProvider.GetRequiredService<IPdfService>();
		}

		// Client info
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

		// Invoice info
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

		// Invoice items for datagrid
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

		// Object for handling invoice item creation
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

		// Object used for changing payment status of the invoice
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

		// Object to hold generated pdf document
		private PdfDocument pdfDocument = new PdfDocument();
		public PdfDocument PdfDocument
		{
			get => pdfDocument;
			set
			{
				pdfDocument = value;
				OnPropertyChanged();
			}
		}

		// Initializes window
		public async Task InitializeAsync(int id)
		{
			this.InvoiceId = id;
			InvoiceVM = await invoiceRepository.GetInvoiceVMAsync(this.InvoiceId);
			ClientVM = await clientRepository.GetClientVMAsync(InvoiceVM.ClientId);
			InvoiceItemVMs = await invoiceItemRepository.GetInvoiceItemVMsAsync(this.InvoiceId);
		}

		// Refreshes after operations
		public async Task RefreshAsync()
		{
			InvoiceVM = await invoiceRepository.GetInvoiceVMAsync(this.InvoiceId);
			InvoiceItemVMs = await invoiceItemRepository.GetInvoiceItemVMsAsync(this.InvoiceId);
		}

		// Creates new invoice item
		public async Task CreateInvoiceItemAsync()
		{
			await invoiceItemRepository.CreateInvoiceItemAsync(CreateInvoiceItemVM, this.InvoiceId);
		}

		// Deletes invoice item
		public async Task DeleteInvoiceItemAsync(int id)
		{
			await invoiceItemRepository.DeleteInvoiceItemAsync(id);
		}

		// Deletes invoice
		public async Task DeleteInvoiceAsync()
		{
			await invoiceRepository.DeleteInvoiceAsync(this.InvoiceId);
		}

		// Creates new payment entity and changes invoice status
		public async Task ChangeInvoiceStatusAsync()
		{
			await paymentRepository.CreatePaymentAsync(this.InvoiceId, NewPaymentDate);
			await invoiceRepository.ChangeInvoiceStatusAsync(this.InvoiceId);
		}

		// Generates pdf file
		public async Task GeneratePdfFileAsync()
		{
			var pdfVM = await invoiceRepository.GetPdfVMAsync(this.InvoiceId);
			PdfDocument = pdfService.GenerateInvoicePdf(pdfVM);
			PdfDocument.Close();
		}
	}
}
