using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.EntityFramework
{
	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args = null)
		{
			DbContextOptionsBuilder<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>();
			options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=InvoiceRegister;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
			return new AppDbContext(options.Options);
		}
	}
}
