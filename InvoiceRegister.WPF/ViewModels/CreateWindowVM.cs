using InvoiceRegister.WPF.Base;
using InvoiceRegister.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.ViewModels
{
	public class CreateWindowVM : ObservableObject
	{
		private CreateVM createVM;
		public CreateVM CreateVM
		{
			get => createVM;
			set
			{
				createVM = value;
				OnPropertyChanged();
			}
		}
	}
}
