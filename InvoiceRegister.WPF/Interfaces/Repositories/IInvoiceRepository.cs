using InvoiceRegister.EntityFramework.Data;
using InvoiceRegister.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Interfaces.Repositories
{
	public interface IInvoiceRepository : IGenericRepository<Invoice>
	{
		Task<ObservableCollection<InvoiceVM>> GetInvoiceVMsAsync();
		Task<ObservableCollection<InvoiceVM>> GetFilteredInvoiceVMsAsync(FilterVM filterVM);
		Task CreateInvoiceAsync(CreateInvoiceVM createInvoiceVM);
		Task<(InvoiceVM invoiceVM, ClientVM clientVM)> GetInvoiceVMAsync(int id);
		Task DeleteInvoiceAsync(int id);
		Task ChangeStatusAsync(int id);
	}
}
