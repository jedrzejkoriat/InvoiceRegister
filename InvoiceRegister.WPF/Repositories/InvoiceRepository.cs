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
	public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
	{
		public InvoiceRepository(AppDbContext context) : base(context)
		{
		}
	}
}
