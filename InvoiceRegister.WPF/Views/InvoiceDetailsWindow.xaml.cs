using InvoiceRegister.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InvoiceRegister.WPF.Views
{
	public partial class InvoiceDetailsWindow : Window
	{
		private readonly InvoiceDetailsWindowVM invoiceDetailsWindowVM;
		public int Id { get; set; }
		public InvoiceDetailsWindow(InvoiceDetailsWindowVM invoiceDetailsWindowVM)
		{
			InitializeComponent();
			this.invoiceDetailsWindowVM = invoiceDetailsWindowVM;
			DataContext = this.invoiceDetailsWindowVM;
		}

		public async Task InitializeAsync()
		{
			await invoiceDetailsWindowVM.InitializeAsync(Id);
		}

		public async void DeleteInvoiceItem_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button?.Tag is int id)
			{
				await invoiceDetailsWindowVM.DeleteInvoiceItemAsync(id);
			}
			await invoiceDetailsWindowVM.RefreshAsync();
		}
		
		public async void AddInvoiceItem_Click(object sender, RoutedEventArgs e)
		{
			await invoiceDetailsWindowVM.CreateInvoiceItemAsync();
			await invoiceDetailsWindowVM.RefreshAsync();
		}

		public async void DeleteInvoice_Click(object sender, RoutedEventArgs e)
		{
			await invoiceDetailsWindowVM.DeleteInvoiceAsync();
			this.Close();
		}

		public async void ChangeStatus_Click(object sender, RoutedEventArgs e)
		{
			await invoiceDetailsWindowVM.ChangeInvoiceStatusAsync();
			await invoiceDetailsWindowVM.RefreshAsync();
		}
	}
}
