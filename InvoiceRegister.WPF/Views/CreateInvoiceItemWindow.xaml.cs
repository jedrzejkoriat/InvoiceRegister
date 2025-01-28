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
	}
}
