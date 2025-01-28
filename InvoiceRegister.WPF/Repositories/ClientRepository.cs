using AutoMapper;
using InvoiceRegister.EntityFramework;
using InvoiceRegister.EntityFramework.Data;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Repositories
{
	public class ClientRepository : GenericRepository<Client>, IClientRepository
	{
		private readonly IMapper mapper;
		private readonly IInvoiceRepository invoiceRepository;

		public ClientRepository(AppDbContext context, IServiceProvider serviceProvider) : base(context)
		{
			this.mapper = serviceProvider.GetRequiredService<IMapper>();
			this.invoiceRepository = serviceProvider.GetRequiredService<IInvoiceRepository>();
		}

		public async Task<ClientVM> GetClientVMAsync(int invoiceId)
		{
			int clientId = (await invoiceRepository.GetAsync(invoiceId)).ClientId;
			return mapper.Map<ClientVM>(await GetAsync(clientId));
		}
	}
}
