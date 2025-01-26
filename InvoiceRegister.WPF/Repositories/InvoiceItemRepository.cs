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
	public class InvoiceItemRepository : GenericRepository<InvoiceItem>, IInvoiceItemRepository
	{
		public InvoiceItemRepository(AppDbContext context) : base(context)
		{
		}
	}
}
