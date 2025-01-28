using AutoMapper;
using InvoiceRegister.EntityFramework;
using InvoiceRegister.WPF.Configurations;
using InvoiceRegister.WPF.Factories;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Repositories;
using InvoiceRegister.WPF.ViewModels;
using InvoiceRegister.WPF.Views;
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
			// Window initialization for asynchronus operations
			await mainWindow.InitializeAsync();
			mainWindow.Show();

			base.OnStartup(e);
		}

		// Depencency Injection configuration
		private IServiceProvider CreateServiceProvider()
		{
			IServiceCollection services = new ServiceCollection();

			// Db context configuration
			services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=InvoiceRegister;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"));

			// Automapper
			services.AddAutoMapper(typeof(MapperConfig));

			// Window factory
			services.AddScoped<IWindowFactory, WindowFactory>();

			// Repositories
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<IClientRepository, ClientRepository>();
			services.AddScoped<ICompanyServiceRepository, CompanyServiceRepository>();
			services.AddScoped<IInvoiceRepository, InvoiceRepository>();
			services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
			services.AddScoped<IPaymentRepository, PaymentRepository>();

			// Views and ViewModels
			services.AddScoped<MainWindowVM>();
			services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowVM>(), s.GetRequiredService<IWindowFactory>()));

			services.AddTransient<CreateInvoiceWindowVM>();
			services.AddTransient<CreateInvoiceWindow>();

			services.AddTransient<CreateInvoiceItemWindowVM>();
			services.AddTransient<CreateInvoiceItemWindow>();

			return services.BuildServiceProvider();
		}
	}

}
