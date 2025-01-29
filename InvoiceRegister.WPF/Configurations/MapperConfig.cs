using AutoMapper;
using InvoiceRegister.EntityFramework.Data;
using InvoiceRegister.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<Invoice, InvoiceVM>().ReverseMap();
			CreateMap<Invoice, CreateInvoiceVM>().ReverseMap();

			CreateMap<InvoiceItem, InvoiceItemVM>().ReverseMap();
			CreateMap<InvoiceItem, CreateInvoiceItemVM>().ReverseMap();

			CreateMap<Client, ClientVM>().ReverseMap();
		}
	}
}
