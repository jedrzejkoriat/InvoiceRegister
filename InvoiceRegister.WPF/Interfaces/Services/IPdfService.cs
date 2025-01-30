using InvoiceRegister.WPF.Models;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Interfaces.Services
{
	public interface IPdfService
	{
		// Generates invoice 
		PdfDocument GenerateInvoicePdf(PdfVM pdfVM);
	}
}
