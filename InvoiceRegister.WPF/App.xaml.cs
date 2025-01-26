using AutoMapper;
using InvoiceRegister.EntityFramework;
using InvoiceRegister.WPF.Configurations;
using InvoiceRegister.WPF.Factories;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Repositories;
using InvoiceRegister.WPF.ViewModels;
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

			services.AddAutoMapper(typeof(MapperConfig));

			services.AddScoped<IWindowFactory, WindowFactory>();

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddTransient<MainWindowVM>();
			services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowVM>(), s.GetRequiredService<IWindowFactory>()));


			return services.BuildServiceProvider();
		}
	}

}
