using InvoiceRegister.WPF.Factories;
using InvoiceRegister.WPF.ViewModels;
using InvoiceRegister.WPF.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InvoiceRegister.WPF
{
	public partial class MainWindow : Window
	{
		private readonly MainWindowVM mainWindowVM;
		private readonly IWindowFactory windowFactory;

		public MainWindow(MainWindowVM mainWindowVM, IWindowFactory windowFactory)
		{
			this.mainWindowVM = mainWindowVM;
			this.windowFactory = windowFactory;
			DataContext = this.mainWindowVM;
		}

		public async Task InitializeAsync()
		{
			await this.mainWindowVM.InitializeAsync();
			InitializeComponent();
		}

		public async void OpenInvoiceDetails_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button?.Tag is int id)
			{
				CreateInvoiceItemWindow createInvoiceItemWindow = windowFactory.CreateWindow<CreateInvoiceItemWindow>(id);
				await createInvoiceItemWindow.InitializeAsync();
				createInvoiceItemWindow.ShowDialog();
				await this.mainWindowVM.InitializeAsync();
				HideColumns();
			}
		}

		public async void OpenInvoiceCreate_Click(object sender, RoutedEventArgs e)
		{
			CreateInvoiceWindow createInvoiceWindow = windowFactory.CreateWindow<CreateInvoiceWindow>(0);
			createInvoiceWindow.ShowDialog();
			await this.mainWindowVM.InitializeAsync();
			HideColumns();
		}

		public void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			HideColumns();
		}

		public async void Filter_Click(object sender, RoutedEventArgs e)
		{
			await this.mainWindowVM.ApplyFilterAsync();
			HideColumns();
		}

		private void HideColumns()
		{
			InvoicesGrid.Columns[1].Visibility = Visibility.Hidden;
			InvoicesGrid.Columns[2].Visibility = Visibility.Hidden;
		}
	}
}