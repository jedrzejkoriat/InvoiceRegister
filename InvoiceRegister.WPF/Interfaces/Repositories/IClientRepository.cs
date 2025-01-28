using InvoiceRegister.EntityFramework.Data;
using InvoiceRegister.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Interfaces.Repositories
{
	public interface IClientRepository : IGenericRepository<Client>
	{
		Task<ClientVM> GetClientVMAsync(int invoiceId);
	}
}
