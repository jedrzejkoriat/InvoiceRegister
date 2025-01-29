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
		// Gets single invoice
		Task<InvoiceVM> GetInvoiceVMAsync(int id);

		// Gets list of all invoices
		Task<ObservableCollection<InvoiceVM>> GetInvoiceVMsAsync();

		// Creates new invoice
		Task CreateInvoiceAsync(CreateInvoiceVM createInvoiceVM);

		// Applies filters to invoices
		Task<ObservableCollection<InvoiceVM>> FilterInvoiceVMsAsync(FilterVM filterVM);

		// Deletes the invoice
		Task DeleteInvoiceAsync(int id);

		// Changes payment status of the invoice
		Task ChangeInvoiceStatusAsync(int id);
	}
}
