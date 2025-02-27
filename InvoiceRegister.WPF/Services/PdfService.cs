﻿using InvoiceRegister.WPF.Interfaces.Services;
using InvoiceRegister.WPF.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace InvoiceRegister.WPF.Services
{
	public class PdfService : IPdfService
	{
		// Generates invoice
		public PdfDocument GenerateInvoicePdf(PdfVM pdfVM)
		{
			// Document
			PdfDocument document = new PdfDocument();
			document.Info.Title = "Faktura";
			PdfPage strona = document.AddPage();

			// Graphics
			XGraphics graphics = XGraphics.FromPdfPage(strona);

			// Font
			XFont fontHeader = new XFont("Arial", 14, XFontStyleEx.Bold);
			XFont font = new XFont("Arial", 10, XFontStyleEx.Regular);
			XFont fontTable = new XFont("Arial", 10, XFontStyleEx.Regular);

			// Initial margin
			int marginLeft = 30;
			int marginTop = 30;

			// Vertical position
			int currentPositionY = marginTop;

			// Invoice header
			graphics.DrawString($"Faktura nr: {pdfVM.InvoiceVM.InvoiceNumber}", fontHeader, XBrushes.Black, marginLeft, marginTop);
			graphics.DrawString($"Data wystawienia: {pdfVM.InvoiceVM.IssueDate.ToString("dd-MM-yyyy")}", font, XBrushes.Black, marginLeft, marginTop + 20);
			graphics.DrawString($"Data sprzedaży: {pdfVM.InvoiceVM.SaleDate.ToString("dd-MM-yyyy")}", font, XBrushes.Black, marginLeft, marginTop + 40);

			// Seller/Buyer section header
			currentPositionY += 100;

			graphics.DrawString("Sprzedający", fontHeader, XBrushes.Black, marginLeft, currentPositionY);
			graphics.DrawString("Kupujący", fontHeader, XBrushes.Black, marginLeft + 300, currentPositionY);

			// Seller/Buyer section content
			currentPositionY += 20;

			graphics.DrawString($"Firma XYZ", font, XBrushes.Black, marginLeft, currentPositionY);
			graphics.DrawString($"{pdfVM.ClientVM.Name}", font, XBrushes.Black, marginLeft + 300, currentPositionY);

			graphics.DrawString($"aleje Jerozolimskie 123", font, XBrushes.Black, marginLeft, currentPositionY + 20);
			graphics.DrawString($"{pdfVM.ClientVM.Street}", font, XBrushes.Black, marginLeft + 300, currentPositionY + 20);

			graphics.DrawString($"02-017 Warszawa", font, XBrushes.Black, marginLeft, currentPositionY + 40);
			graphics.DrawString($"{pdfVM.ClientVM.PostCode} {pdfVM.ClientVM.City}", font, XBrushes.Black, marginLeft + 300, currentPositionY + 40);

			graphics.DrawString($"NIP: 0001112223", font, XBrushes.Black, marginLeft, currentPositionY + 60);
			graphics.DrawString($"NIP: {pdfVM.ClientVM.NIP}", font, XBrushes.Black, marginLeft + 300, currentPositionY + 60);

			// Table with invoice items (header)
			currentPositionY += 120;

			graphics.DrawString("Nr", fontTable, XBrushes.Black, marginLeft, currentPositionY);
			graphics.DrawString("Nazwa", fontTable, XBrushes.Black, marginLeft + 40, currentPositionY);
			graphics.DrawString("Ilość", fontTable, XBrushes.Black, marginLeft + 120, currentPositionY);
			graphics.DrawString("Cena netto", fontTable, XBrushes.Black, marginLeft + 180, currentPositionY);
			graphics.DrawString("Wartość netto", fontTable, XBrushes.Black, marginLeft + 250, currentPositionY);
			graphics.DrawString("VAT", fontTable, XBrushes.Black, marginLeft + 330, currentPositionY);
			graphics.DrawString("Wartość VAT", fontTable, XBrushes.Black, marginLeft + 380, currentPositionY);
			graphics.DrawString("Wartość brutto", fontTable, XBrushes.Black, marginLeft + 450, currentPositionY);

			graphics.DrawRectangle(new XPen(XColors.Black), marginLeft - 5, currentPositionY - 15, 540, 20);

			// Table with invoice items (content)
			currentPositionY += 20;
			for (int i = 0; i < pdfVM.IvoiceItemVMs.Count; i++)
			{
				graphics.DrawString((i + 1).ToString(), fontTable, XBrushes.Black, marginLeft, currentPositionY);
				graphics.DrawString(pdfVM.IvoiceItemVMs[i].Name, fontTable, XBrushes.Black, marginLeft + 40, currentPositionY);
				graphics.DrawString(pdfVM.IvoiceItemVMs[i].Amount.ToString(), fontTable, XBrushes.Black, marginLeft + 120, currentPositionY);
				graphics.DrawString(pdfVM.IvoiceItemVMs[i].Price.ToString(), fontTable, XBrushes.Black, marginLeft + 180, currentPositionY);
				graphics.DrawString(pdfVM.IvoiceItemVMs[i].ValueNet.ToString(), fontTable, XBrushes.Black, marginLeft + 250, currentPositionY);
				graphics.DrawString(pdfVM.IvoiceItemVMs[i].VAT.ToString() + "%", fontTable, XBrushes.Black, marginLeft + 330, currentPositionY);
				graphics.DrawString(pdfVM.IvoiceItemVMs[i].ValueVAT.ToString(), fontTable, XBrushes.Black, marginLeft + 380, currentPositionY);
				graphics.DrawString(pdfVM.IvoiceItemVMs[i].PriceGross.ToString(), fontTable, XBrushes.Black, marginLeft + 450, currentPositionY);

				graphics.DrawRectangle(new XPen(XColors.Black), marginLeft - 5, currentPositionY - 15, 540, 20);
				currentPositionY += 20;
			}

			// Summary header
			currentPositionY += 10;

			graphics.DrawString("Podsumowanie", fontHeader, XBrushes.Black, marginLeft + 400, currentPositionY);

			// Summary content
			currentPositionY += 20;

			graphics.DrawString($"Wartość netto: {pdfVM.InvoiceVM.ValueNet}", font, XBrushes.Black, marginLeft + 400, currentPositionY);
			graphics.DrawString($"Wartość VAT: {pdfVM.InvoiceVM.ValueVAT}", font, XBrushes.Black, marginLeft + 400, currentPositionY + 20);
			graphics.DrawString($"Wartość brutto: {pdfVM.InvoiceVM.PriceGross}", font, XBrushes.Black, marginLeft + 400, currentPositionY + 40);

			currentPositionY += 60;
			graphics.DrawString($"Całkowita kwota: {pdfVM.InvoiceVM.PriceGross}", fontHeader, XBrushes.Black, marginLeft, currentPositionY);

			// Payment details section
			currentPositionY = 670;
			graphics.DrawString("Termin płatności", font, XBrushes.Black, marginLeft, currentPositionY);
			graphics.DrawString($"{pdfVM.InvoiceVM.PaymentDueDate.ToString("dd-MM-yyyy")}", font, XBrushes.Black, marginLeft + 100, currentPositionY);

			currentPositionY += 20;
			graphics.DrawString("Sposób płatności", font, XBrushes.Black, marginLeft, currentPositionY);
			graphics.DrawString("Przelew", font, XBrushes.Black, marginLeft + 100, currentPositionY);

			currentPositionY += 20;
			graphics.DrawString("Numer konta", font, XBrushes.Black, marginLeft, currentPositionY);
			graphics.DrawString("PL 00 1111 2222 3333 4444 5555 6666", font, XBrushes.Black, marginLeft + 100, currentPositionY);

			currentPositionY += 20;
			graphics.DrawString("Bank", font, XBrushes.Black, marginLeft, currentPositionY);
			graphics.DrawString("XYZ Bank", font, XBrushes.Black, marginLeft + 100, currentPositionY);

			// Signature section
			currentPositionY += 70;
			graphics.DrawLine(new XPen(XColors.Black, 0.2), marginLeft + 20, currentPositionY, marginLeft + 200, currentPositionY);
			graphics.DrawLine(new XPen(XColors.Black, 0.2), marginLeft + 330, currentPositionY, marginLeft + 510, currentPositionY);

			currentPositionY += 10;

			graphics.DrawString("Osoba upoważniona do sprzedaży", font, XBrushes.Black, marginLeft + 30, currentPositionY);
			graphics.DrawString("Osoba upoważniona do kupna", font, XBrushes.Black, marginLeft + 350, currentPositionY);

			// Document saving
			return document;
			//document.Save($"{pdfVM.InvoiceVM.InvoiceNumber}.pdf");
		}
	}
}
