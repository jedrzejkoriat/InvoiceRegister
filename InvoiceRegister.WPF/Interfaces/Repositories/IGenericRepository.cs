using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Interfaces.Repositories
{
	// Generic repository to handle basic database operations
	public interface IGenericRepository<T> where T : class
	{
		// Add entity of T type
		Task AddAsync(T entity);

		// Delete entity of T type
		Task DeleteAsync(int id);

		// Update entity of T type
		Task UpdateAsync(T entity);

		// Get all entities of T type
		Task<List<T>> GetAllAsync();

		// Get entity of T type
		Task<T> GetAsync(int? id);

	}
}
