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
		Task<ObservableCollection<InvoiceItemVM>> GetInvoiceItemVMsAsync(int invoiceId);
		Task CreateInvoiceItemAsync(CreateInvoiceItemVM createInvoiceItemVM, int invoiceId);
		Task DeleteInvoiceItemAsync(int id);
	}
}
