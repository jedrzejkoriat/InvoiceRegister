using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : class
	{
		Task AddAsync(T entity);
		Task DeleteAsync(int id);
		Task UpdateAsync(T entity);
		Task<T> GetAsync(int? id);
		Task<List<T>> GetAllAsync();
		
	}
}
