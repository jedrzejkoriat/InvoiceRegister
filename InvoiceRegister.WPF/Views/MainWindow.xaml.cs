﻿using InvoiceRegister.WPF.Factories;
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
	/// <summary>
	/// 
	/// This window handles:
	/// - Displaying invoice datagrid
	/// - Filtering invoices
	/// 
	/// </summary>

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

		// Initialize
		public async Task InitializeAsync()
		{
			await this.mainWindowVM.InitializeAsync();
			InitializeComponent();
		}

		// Hiding columns after the mainwindow is loaded on app launch
		public void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			HideColumns();
		}

		// Open invoice details window - passes id to window factory to initialize with specific invoice
		public async void OpenInvoiceDetails_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button?.Tag is int id)
			{
				InvoiceDetailsWindow createInvoiceDetailsWindow = windowFactory.CreateWindow<InvoiceDetailsWindow>(id);
				await createInvoiceDetailsWindow.InitializeAsync();
				createInvoiceDetailsWindow.ShowDialog();

				await RefreshWindowVM();
			}
		}

		// Open invoice create form
		public async void OpenInvoiceCreate_Click(object sender, RoutedEventArgs e)
		{
			CreateInvoiceWindow createInvoiceWindow = windowFactory.CreateWindow<CreateInvoiceWindow>(0);
			createInvoiceWindow.ShowDialog();

			await RefreshWindowVM();
		}

		// Filter datagrid objects
		public async void Filter_Click(object sender, RoutedEventArgs e)
		{
			await this.mainWindowVM.ApplyFilterAsync();
			HideColumns();
		}

		// Method for hiding Id columns in the datagrid
		private void HideColumns()
		{
			InvoicesGrid.Columns[1].Visibility = Visibility.Hidden;
			InvoicesGrid.Columns[2].Visibility = Visibility.Hidden;
		}

		// Refreshing main window VM after other operations
		private async Task RefreshWindowVM()
		{
			await this.mainWindowVM.RefreshAsync();
			HideColumns();
		}
	}
}