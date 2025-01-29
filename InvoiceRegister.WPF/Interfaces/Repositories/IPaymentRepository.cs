using InvoiceRegister.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Interfaces.Repositories
{
	public interface IPaymentRepository : IGenericRepository<Payment>
	{
		Task<bool> CreatePaymentAsync(int invoiceId, DateTime paymentDate);
	}
}
