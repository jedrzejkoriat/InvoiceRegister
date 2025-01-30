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
	public interface IInvoiceItemRepository : IGenericRepository<InvoiceItem>
	{
		// Gets the list of invoice items
		Task<ObservableCollection<InvoiceItemVM>> GetInvoiceItemVMsAsync(int invoiceId);

		// Create new invoice item
		Task CreateInvoiceItemAsync(CreateInvoiceItemVM createInvoiceItemVM, int invoiceId);

		// Deletes invoice item
		Task DeleteInvoiceItemAsync(int id);

		// Get the invoice items, value net and value vat for pdf generating
		Task<(List<InvoiceItemVM> invoiceVMs, decimal valueNet, decimal valueVAT)> GetInvoiceItemsForPdfVM(int invoiceId);
	}
}
