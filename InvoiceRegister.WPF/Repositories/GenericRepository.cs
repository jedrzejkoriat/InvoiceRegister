using InvoiceRegister.EntityFramework;
using InvoiceRegister.WPF.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Repositories
{
	// Generic repository to handle basic database operations
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly AppDbContext context;

		public GenericRepository(AppDbContext context)
		{
			this.context = context;
		}
		
		// Add entity of T type
		public async Task AddAsync(T entity)
		{
			await context.AddAsync(entity);
			await context.SaveChangesAsync();
		}

		// Delete entity of T type
		public async Task DeleteAsync(int id)
		{
			var entity = await context.Set<T>().FindAsync(id);
			context.Set<T>().Remove(entity);
			await context.SaveChangesAsync();
		}

		// Update entity of T type
		public async Task UpdateAsync(T entity)
		{
			context.Update(entity);
			await context.SaveChangesAsync();
		}

		// Get all entities of T type
		public async Task<List<T>> GetAllAsync()
		{
			return await context.Set<T>().ToListAsync();
		}

		// Get entity of T type
		public async Task<T> GetAsync(int? id)
		{
			if (id == null)
			{
				return null;
			}
			return await context.Set<T>().FindAsync(id);
		}
	}
}
