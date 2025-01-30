using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InvoiceRegister.EntityFramework
{
	// Db context factory to instantiate db context at design time
	public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args = null)
		{
			// Get the appsettings.json directory
			var projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

			// Get the appsettings.json file path
			var configFilePath = Path.Combine(projectDirectory, "appsettings.json");

			var configuration = new ConfigurationBuilder()
				.SetBasePath(projectDirectory)
				.AddJsonFile(configFilePath, optional: true, reloadOnChange: true)
				.Build();

			DbContextOptionsBuilder<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>();
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

			return new AppDbContext(options.Options);
		}
	}
}
