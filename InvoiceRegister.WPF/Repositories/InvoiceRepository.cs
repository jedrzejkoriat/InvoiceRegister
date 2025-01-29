using AutoMapper;
using InvoiceRegister.EntityFramework;
using InvoiceRegister.EntityFramework.Data;
using InvoiceRegister.WPF.Base.Exceptions;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Repositories
{
	public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
	{
		private readonly IMapper mapper;
		private readonly IPaymentRepository paymentRepository;
		private readonly IInvoiceItemRepository invoiceItemRepository;
		private readonly IClientRepository clientRepository;

		public InvoiceRepository(AppDbContext context, IServiceProvider serviceProvider) : base(context)
		{
			this.mapper = serviceProvider.GetRequiredService<IMapper>();
			this.paymentRepository = serviceProvider.GetRequiredService<IPaymentRepository>();
			this.invoiceItemRepository = serviceProvider.GetRequiredService<IInvoiceItemRepository>();
			this.clientRepository = serviceProvider.GetRequiredService<IClientRepository>();
		}

		// Gets single invoice
		public async Task<InvoiceVM> GetInvoiceVMAsync(int id)
		{
			return await GetInvoiceVMRelatedData(mapper.Map<InvoiceVM>(await GetAsync(id)));
		}

		// Gets list of all invoices
		public async Task<ObservableCollection<InvoiceVM>> GetInvoiceVMsAsync()
		{
			var invoiceVMs = mapper.Map<ObservableCollection<InvoiceVM>>(await GetAllAsync());

			foreach (var invoiceVM in invoiceVMs)
			{
				await GetInvoiceVMRelatedData(invoiceVM);
			}

			return invoiceVMs;
		}

		// Creates new invoice
		public async Task CreateInvoiceAsync(CreateInvoiceVM createInvoiceVM)
		{
			// Checks if the invoice number is null or doesn't match the pattern
			if (createInvoiceVM.InvoiceNumber == null || !Regex.IsMatch(createInvoiceVM.InvoiceNumber, @"^INV/\d{4}/\d{2}/\d{2}/\d+$"))
			{
				throw new InvoiceNumberException("Invalid invoice number format.");
			}
			// Checks if the invoice with such number exsists
			else if ((await GetAllAsync()).Any(i => i.InvoiceNumber == createInvoiceVM.InvoiceNumber))
			{
				throw new InvoiceNumberException("Invoice with this number already exsists.");
			}
			// Checks if the NIP format is invalid
			else if (createInvoiceVM.ClientNIP.Length != 10 || !createInvoiceVM.ClientNIP.All(char.IsDigit))
			{
				throw new InvoiceNIPException("Invalid NIP format.");
			}
			
			var client = (await clientRepository.GetAllAsync()).Where(c => c.NIP == createInvoiceVM.ClientNIP).SingleOrDefault();

			// Checks if client with entered NIP exsists in the database 
			if (client == null)
			{
				throw new InvoiceNIPException("Client with this NIP does not exsist.");
			}

			// Creates the invoice on success
			var newInvoice = mapper.Map<Invoice>(createInvoiceVM);
			newInvoice.IsPaid = false;
			newInvoice.ClientId = client.Id;
			
			await AddAsync(newInvoice);
		}

		// Applies filters to invoices
		public async Task<ObservableCollection<InvoiceVM>> FilterInvoiceVMsAsync(FilterVM filterVM)
		{
			var filteredInvoices = (await GetInvoiceVMsAsync()).AsEnumerable();

			// All filters
			if (filterVM.FromDateToggle) filteredInvoices = filteredInvoices.Where(i => i.IssueDate >= filterVM.FromDate);
			if (filterVM.ToDateToggle) filteredInvoices = filteredInvoices.Where(i => i.IssueDate <= filterVM.ToDate);
			if (filterVM.MinPriceToggle) filteredInvoices = filteredInvoices.Where(i => i.PriceGross >= filterVM.MinPrice);
			if (filterVM.MaxPriceToggle) filteredInvoices = filteredInvoices.Where(i => i.PriceGross <= filterVM.MaxPrice);
			if (filterVM.ClientNameToggle) filteredInvoices = filteredInvoices.Where(i => i.ClientName.Contains(filterVM.ClientName));
			if (filterVM.ClientNIPToggle) filteredInvoices = filteredInvoices.Where(i => i.ClientNIP == filterVM.ClientNIP);
			if (filterVM.OverduePaymentToggle) filteredInvoices = filteredInvoices.Where(i => i.PaymentDate == null && i.PaymentDueDate < DateTime.UtcNow);

			return new ObservableCollection<InvoiceVM>(filteredInvoices);
		}

		// Deletes the invoice
		public async Task DeleteInvoiceAsync(int id)
		{
			await DeleteAsync(id);
		}

		// Changes payment status of the invoice
		public async Task ChangeInvoiceStatusAsync(int id)
		{
			var invoice = await GetAsync(id);
			invoice.IsPaid = true;
			await UpdateAsync(invoice);
		}

		// Private methods below

		// Gets the invoiceVM data from payment, invoice item and client repositories
		private async Task<InvoiceVM> GetInvoiceVMRelatedData(InvoiceVM invoiceVM)
		{
			// Gets the payment date based on the payment status
			if (invoiceVM.IsPaid)
			{
				invoiceVM.PaymentDate = (await paymentRepository.GetAllAsync())
					.SingleOrDefault(p => p.InvoiceId == invoiceVM.Id)?.PaymentDate;
			}

			// Gets the overall gross price of the invoice
			invoiceVM.PriceGross = (await invoiceItemRepository.GetAllAsync())
				.Where(i => i.InvoiceId == invoiceVM.Id)
				.Sum(i => Math.Round((i.Price * i.Amount) * (1.00m + i.VAT / 100.00m), 2));

			// Gets the client data
			var client = await clientRepository.GetAsync(invoiceVM.ClientId);
			invoiceVM.ClientName = client.Name;
			invoiceVM.ClientNIP = client.NIP;

			return invoiceVM;
		}
	}
}
