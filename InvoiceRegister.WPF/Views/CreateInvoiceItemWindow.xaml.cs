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
	public partial class CreateInvoiceItemWindow : Window
	{
		private readonly CreateInvoiceItemWindowVM createInvoiceItemWindowVM;
		public int Id { get; set; }
		public CreateInvoiceItemWindow(CreateInvoiceItemWindowVM createInvoiceItemWindowVM)
		{
			InitializeComponent();
			this.createInvoiceItemWindowVM = createInvoiceItemWindowVM;
			DataContext = this.createInvoiceItemWindowVM;
		}

		public async Task InitializeAsync()
		{
			await createInvoiceItemWindowVM.InitializeAsync(Id);
		}

		public async void DeleteInvoiceItem_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button?.Tag is int id)
			{
				await createInvoiceItemWindowVM.DeleteInvoiceItemAsync(id);
			}
			await createInvoiceItemWindowVM.RefreshAsync();
		}
		
		public async void AddInvoiceItem_Click(object sender, RoutedEventArgs e)
		{
			await createInvoiceItemWindowVM.CreateInvoiceItemAsync();
			await createInvoiceItemWindowVM.RefreshAsync();
		}
	}
}
