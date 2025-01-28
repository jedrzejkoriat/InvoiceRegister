using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Models
{
	public class FilterVM
	{
		public DateTime FromDate { get; set; } = DateTime.Now;
		public bool FromDateToggle { get; set; } = false;
		public DateTime ToDate { get; set; } = DateTime.Now;
		public bool ToDateToggle { get; set; } = false;
		public decimal MinPrice { get; set; } = 0m;
		public bool MinPriceToggle { get; set; } = false;
		public decimal MaxPrice { get; set; } = 0m;
		public bool MaxPriceToggle { get; set; } = false;
		public string ClientNIP { get; set; } = "";
		public bool ClientNIPToggle { get; set; } = false;
		public string ClientName { get; set; } = "";
		public bool ClientNameToggle { get; set; } = false;
		public bool OverduePaymentToggle { get; set; } = false;
	}
}
