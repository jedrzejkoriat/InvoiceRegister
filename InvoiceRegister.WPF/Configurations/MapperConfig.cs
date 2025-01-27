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
			CreateMap<Client, ClientVM>().ReverseMap();
			CreateMap<Invoice, InvoiceVM>().ReverseMap();
			CreateMap<InvoiceItem, InvoiceVM>().ReverseMap();
			CreateMap<Payment, PaymentVM>().ReverseMap();
			CreateMap<CompanyService, CompanyServiceVM>().ReverseMap();
		}
	}
}
