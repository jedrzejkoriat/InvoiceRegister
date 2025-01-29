using AutoMapper;
using InvoiceRegister.EntityFramework;
using InvoiceRegister.EntityFramework.Data;
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

		public async Task<ObservableCollection<InvoiceItemVM>> GetInvoiceItemVMsAsync(int invoiceId)
		{
			return mapper.Map<ObservableCollection<InvoiceItemVM>>((await GetAllAsync()).Where(i => i.InvoiceId == invoiceId));
		}

		public async Task CreateInvoiceItemAsync(CreateInvoiceItemVM createInvoiceItemVM, int invoiceId)
		{
			var invoiceItem = mapper.Map<InvoiceItem>(createInvoiceItemVM);
			invoiceItem.InvoiceId = invoiceId;

			await AddAsync(invoiceItem);
		}

		public async Task DeleteInvoiceItemAsync(int id)
		{
			await DeleteAsync(id);
		}
	}
}
