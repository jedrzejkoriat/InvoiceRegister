using InvoiceRegister.WPF.Configurations.Exceptions;
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
	public partial class CreateInvoiceWindow : Window
	{
		private readonly CreateInvoiceWindowVM createInvoiceWindowVM;
		public CreateInvoiceWindow(CreateInvoiceWindowVM createInvoiceWindowVM, IServiceProvider serviceProvider)
		{
			InitializeComponent();
			this.createInvoiceWindowVM = createInvoiceWindowVM;
			DataContext = this.createInvoiceWindowVM;
		}

		public async void CreateInvoice_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				await this.createInvoiceWindowVM.CreateInvoice();
			}
			catch (NIPException ex)
			{
				ErrorText.Text = ex.Message;
				return;
			}
			catch (InvoiceNumberException ex)
			{
				ErrorText.Text = ex.Message;
				return;
			}
			catch
			{
				ErrorText.Text = "Unexpected error occurred";
				return;
			}
			this.Close();
		}
	}
}
