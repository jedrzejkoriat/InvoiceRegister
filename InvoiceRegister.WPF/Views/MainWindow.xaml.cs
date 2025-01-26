using InvoiceRegister.WPF.Factories;
using InvoiceRegister.WPF.ViewModels;
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

		public MainWindow(MainWindowVM mainWindowVM, IWindowFactory windowFactory)
		{
			this.mainWindowVM = mainWindowVM;
			DataContext = this.mainWindowVM;
		}

		public async Task InitializeAsync()
		{
			await this.mainWindowVM.InitializeAsync();
			InitializeComponent();
		}
	}
}