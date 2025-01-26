using InvoiceRegister.EntityFramework;
using InvoiceRegister.EntityFramework.Data;
using InvoiceRegister.WPF.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Repositories
{
	public class ClientRepository : GenericRepository<Client>, IClientRepository
	{
		public ClientRepository(AppDbContext context) : base(context)
		{
		}
	}
}
