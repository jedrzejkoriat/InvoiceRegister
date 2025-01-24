using InvoiceRegister.EntityFramework;
using InvoiceRegister.WPF.Factories;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace InvoiceRegister.WPF
{
	public partial class App : Application
	{
		protected override async void OnStartup(StartupEventArgs e)
		{
			IServiceProvider serviceProvider = CreateServiceProvider();

			MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();
			mainWindow.Show();

			base.OnStartup(e);
		}

		private IServiceProvider CreateServiceProvider()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=InvoiceRegister;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"));

			services.AddScoped<IWindowFactory, WindowFactory>();

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			return services.BuildServiceProvider();
		}
	}

}
