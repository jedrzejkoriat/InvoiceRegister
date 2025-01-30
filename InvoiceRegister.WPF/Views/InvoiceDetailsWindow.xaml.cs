using InvoiceRegister.WPF.Base.Exceptions;
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
	/// <summary>
	/// 
	/// This window handles:
	/// - Displaying invoice items data grid
	/// - Deleting invoice items
	/// - Creating invoice items
	/// - Deleting invoices
	/// - Changing invoice payment status + Creating payment entities
	/// 
	/// </summary>

	public partial class InvoiceDetailsWindow : Window
	{
		public int InvoiceId { get; set; }

		private readonly InvoiceDetailsWindowVM invoiceDetailsWindowVM;
		public InvoiceDetailsWindow(InvoiceDetailsWindowVM invoiceDetailsWindowVM)
		{
			this.invoiceDetailsWindowVM = invoiceDetailsWindowVM;
			DataContext = this.invoiceDetailsWindowVM;
		}

		// Initialize
		public async Task InitializeAsync()
		{
			await invoiceDetailsWindowVM.InitializeAsync(InvoiceId);
			InitializeComponent();
		}

		// Hiding columns after the window is loaded
		public void InvoiceDetailsWindow_Loaded(object sender, RoutedEventArgs e)
		{
			HideColumns();
		}

		// Detele invoice item
		public async void DeleteInvoiceItem_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button?.Tag is int id)
			{
				await invoiceDetailsWindowVM.DeleteInvoiceItemAsync(id);
			}
			await RefreshWindowVM();
		}

		// Add invoice item
		public async void AddInvoiceItem_Click(object sender, RoutedEventArgs e)
		{
			// Try creating invoice item and display adequate errors on fail
			try
			{
				await invoiceDetailsWindowVM.CreateInvoiceItemAsync();
			}
			catch (InvoiceItemNameException ex)
			{
				HideErrors();
				ErrorText.Text = ex.Message;
				ErrorText.Height = 20;
				NameWarning.Visibility = Visibility.Visible;
				return;
			}
			catch (InvoiceItemAmountException ex)
			{
				HideErrors();
				ErrorText.Text = ex.Message;
				ErrorText.Height = 20;
				AmountWarning.Visibility = Visibility.Visible;
				return;
			}
			catch (InvoiceItemPriceException ex)
			{
				HideErrors();
				ErrorText.Text = ex.Message;
				ErrorText.Height = 20;
				PriceWarning.Visibility = Visibility.Visible;
				return;
			}
			catch (InvoiceItemVATException ex)
			{
				HideErrors();
				ErrorText.Text = ex.Message;
				ErrorText.Height = 20;
				VATWarning.Visibility = Visibility.Visible;
				return;
			}

			// Refresh window and clear errortext on success
			ErrorText.Text = "";
			ErrorText.Height = 0;

			await RefreshWindowVM();
		}

		// Delete invoice
		public async void DeleteInvoice_Click(object sender, RoutedEventArgs e)
		{
			await invoiceDetailsWindowVM.DeleteInvoiceAsync();
			this.Close();
		}

		// Change invoice status to paid
		public async void ChangeStatus_Click(object sender, RoutedEventArgs e)
		{
			await invoiceDetailsWindowVM.ChangeInvoiceStatusAsync();
			await RefreshWindowVM();
		}

		// Method for hiding Id columns in the datagrid
		private void HideColumns()
		{
			for (int i = 6; i < InvoiceItemsGrid.Columns.Count; i++)
			{
				InvoiceItemsGrid.Columns[i].Visibility = Visibility.Hidden;
			}
		}

		// Refreshing main window VM after other operations
		private async Task RefreshWindowVM()
		{
			await invoiceDetailsWindowVM.RefreshAsync();
			HideColumns();
		}

		private void HideErrors()
		{
			ErrorText.Text = "";
			ErrorText.Height = 0;
			NameWarning.Visibility = Visibility.Hidden;
			AmountWarning.Visibility = Visibility.Hidden;
			PriceWarning.Visibility = Visibility.Hidden;
			VATWarning.Visibility = Visibility.Hidden;
		}
    }
}
