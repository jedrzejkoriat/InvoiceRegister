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
	/// - Creating new invoices
	/// 
	/// </summary>

	public partial class CreateInvoiceWindow : Window
	{
		private readonly CreateInvoiceWindowVM createInvoiceWindowVM;
		public CreateInvoiceWindow(CreateInvoiceWindowVM createInvoiceWindowVM)
		{
			InitializeComponent();
			this.createInvoiceWindowVM = createInvoiceWindowVM;
			DataContext = this.createInvoiceWindowVM;
		}

		// Creating new invoice entity
		public async void CreateInvoice_Click(object sender, RoutedEventArgs e)
		{
			// Try creating invoice and display adequate errors on fail
			try
			{
				await this.createInvoiceWindowVM.CreateInvoice();
			}
			catch (InvoiceNIPException ex)
			{
				ErrorText.Text = ex.Message;
				NIPWarning.Visibility = Visibility.Visible;
				return;
			}
			catch (InvoiceNumberException ex)
			{
				ErrorText.Text = ex.Message;
				NumberWarning.Visibility = Visibility.Visible;
				return;
			}
			catch
			{
				ErrorText.Text = "Unexpected error occurred.";
				return;
			}

			// Close window on success
			this.Close();
		}
	}
}
