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
	public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
	{
		public PaymentRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<bool> CreatePaymentAsync(int invoiceId, DateTime paymentDate)
		{
			if ((await GetAllAsync()).Any(p => p.InvoiceId == invoiceId))
			{
				return false;
			}

			var payment = new Payment { InvoiceId = invoiceId, PaymentDate = paymentDate };
			await AddAsync(payment);
			return true;
		}
	}
}
