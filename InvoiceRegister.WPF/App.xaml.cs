using AutoMapper;
using InvoiceRegister.EntityFramework;
using InvoiceRegister.WPF.Configurations;
using InvoiceRegister.WPF.Factories;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Interfaces.Services;
using InvoiceRegister.WPF.Repositories;
using InvoiceRegister.WPF.Services;
using InvoiceRegister.WPF.ViewModels;
using InvoiceRegister.WPF.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
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
			// Get the appsettings.json directory
			var projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

			// Get the appsettings.json file path
			var configFilePath = Path.Combine(projectDirectory, "appsettings.json");

			var configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(projectDirectory)
				.AddJsonFile(configFilePath, optional: true, reloadOnChange: true);

			IServiceCollection services = new ServiceCollection();
			IConfiguration configuration = configurationBuilder.Build();

			// Db context
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			// Automapper
			services.AddAutoMapper(typeof(MapperConfig));

			// Window factory
			services.AddScoped<IWindowFactory, WindowFactory>();

			// Repositories
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddScoped<IClientRepository, ClientRepository>();
			services.AddScoped<IInvoiceRepository, InvoiceRepository>();
			services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
			services.AddScoped<IPaymentRepository, PaymentRepository>();

			// Send grid connection string and email
			string sendGridConnectionString = configuration.GetConnectionString("SendGridConnectionString");
			string sendFromEmailAddress = configuration.GetConnectionString("SendFromEmail");

			// Services
			services.AddScoped<IEmailSenderService, EmailSenderService>(provider => new EmailSenderService(sendGridConnectionString, sendFromEmailAddress));

			// Views and ViewModels
			services.AddScoped<MainWindow>();
			services.AddScoped<MainWindowVM>();

			services.AddTransient<CreateInvoiceWindow>();
			services.AddTransient<CreateInvoiceWindowVM>();

			services.AddTransient<InvoiceDetailsWindow>();
			services.AddTransient<InvoiceDetailsWindowVM>();

			return services.BuildServiceProvider();
		}
	}

}
