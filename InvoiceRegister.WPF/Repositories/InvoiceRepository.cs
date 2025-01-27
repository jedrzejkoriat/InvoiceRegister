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

		public async Task<ObservableCollection<InvoiceVM>> GetInvoiceVMsAsync()
		{
			var invoiceVMs = mapper.Map<ObservableCollection<InvoiceVM>>(await GetAllAsync());

			foreach (var invoiceVM in invoiceVMs)
			{
				invoiceVM.PaymentDate = (await paymentRepository.GetAllAsync())
					.SingleOrDefault(p => p.InvoiceId == invoiceVM.Id)?.PaymentDate ?? null;
				invoiceVM.PriceGross = (await invoiceItemRepository.GetAllAsync())
					.Where(i => i.InvoiceId == invoiceVM.Id)
					.Sum(i => Math.Round((i.Price * i.Amount) * (1.00m + i.VAT / 100.00m), 2));

				var client = await clientRepository.GetAsync(invoiceVM.ClientId);
				invoiceVM.ClientName = client.Name;
				invoiceVM.ClientNIP = client.NIP;

			}

			return invoiceVMs;
		}
	}
}
