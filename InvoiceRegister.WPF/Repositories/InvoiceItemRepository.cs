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
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Repositories
{
	public class InvoiceItemRepository : GenericRepository<InvoiceItem>, IInvoiceItemRepository
	{
		IMapper mapper;
		public InvoiceItemRepository(AppDbContext context, IServiceProvider serviceProvider) : base(context)
		{
			this.mapper = serviceProvider.GetRequiredService<IMapper>();
		}

		// Get the list of invoice items
		public async Task<ObservableCollection<InvoiceItemVM>> GetInvoiceItemVMsAsync(int invoiceId)
		{	
			var invoiceItem = mapper.Map<ObservableCollection<InvoiceItemVM>>((await GetAllAsync()).Where(i => i.InvoiceId == invoiceId));

			foreach (var item in invoiceItem)
			{
				item.ValueNet = item.Price * item.Amount;
				item.ValueVAT = Math.Round(item.ValueNet * (item.VAT / 100m), 2);
				item.PriceGross = item.ValueNet + item.ValueVAT;
			}

			return invoiceItem;
		}

		// Get the invoice items, value net and value vat for pdf generating
		public async Task<(List<InvoiceItemVM> invoiceVMs, decimal valueNet, decimal valueVAT)> GetInvoiceItemsForPdfVM(int invoiceId)
		{
			var invoiceItem = mapper.Map<List<InvoiceItemVM>>((await GetAllAsync()).Where(i => i.InvoiceId == invoiceId));

			decimal valueNet = 0m;
			decimal valueVAT = 0m;

			foreach (var item in invoiceItem)
			{
				item.ValueNet = item.Price * item.Amount;
				item.ValueVAT = Math.Round(item.ValueNet * (item.VAT / 100m), 2);
				item.PriceGross = item.ValueNet + item.ValueVAT;

				valueNet += item.ValueNet;
				valueVAT += item.ValueVAT;
			}

			return (invoiceItem, valueNet, valueVAT);
		}

		// Creates invoice item
		public async Task CreateInvoiceItemAsync(CreateInvoiceItemVM createInvoiceItemVM, int invoiceId)
		{
			// Checks if name is null or length is 0
			if (createInvoiceItemVM.Name == null || createInvoiceItemVM.Name.Length == 0)
			{
				throw new InvoiceItemNameException("Enter the name of the item.");
			}
			// Checks if invoice item amoun is less or equal 0
			else if (createInvoiceItemVM.Amount <= 0)
			{
				throw new InvoiceItemAmountException("Item amount cannot be lower or equal 0.");
			}
			// Checks if price is less or equal 0
			else if (createInvoiceItemVM.Price <= 0)
			{
				throw new InvoiceItemPriceException("Item price cannot be lower or equal 0.");
			}
			// Checks if the VAT was incorrectly entered
			else if (!new[] { 0, 5, 8, 23 }.Contains(createInvoiceItemVM.VAT))
			{
				throw new InvoiceItemVATException("VAT has to be: 0, 5, 8 or 23.");
			}

			// Creates invoice item on success
			var invoiceItem = mapper.Map<InvoiceItem>(createInvoiceItemVM);
			invoiceItem.InvoiceId = invoiceId;
			invoiceItem.Price = Math.Round(invoiceItem.Price, 2);
			await AddAsync(invoiceItem);
		}

		// Deletes invoice item
		public async Task DeleteInvoiceItemAsync(int id)
		{
			await DeleteAsync(id);
		}
	}
}
