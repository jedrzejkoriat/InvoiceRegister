using Azure.Core;
using InvoiceRegister.WPF.Interfaces.Repositories;
using InvoiceRegister.WPF.Interfaces.Services;
using InvoiceRegister.WPF.Models;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Services
{
	public class EmailSenderService : IEmailSenderService
	{
		private readonly string sendGridConnectionString;
		private readonly string sendFromEmailAddress;

		public EmailSenderService(string sendGridConnectionString, string sendFromEmailAddress)
		{
			this.sendGridConnectionString = sendGridConnectionString;
			this.sendFromEmailAddress = sendFromEmailAddress;
		}

		// Sends email to all clients with overdue payments
		public async Task SendWarningEmailsAsync(List<OverdueInvoiceVM> overdueInvoices)
		{
			var client = new SendGridClient(sendGridConnectionString);
			var sendFrom = new EmailAddress(sendFromEmailAddress);

			foreach (var invoice in overdueInvoices)
			{
				string email = invoice.Email;
				string subject = $"	Payment Reminder - Invoice No. {invoice.InvoiceNumber}"; 
				string htmlMessage =	$@"
									Dear Sir/Madam,

									We would like to remind you that the payment for invoice number {invoice.InvoiceNumber} in the amount of {invoice.PriceGross:C2} was due on {invoice.PaymentDueDate.ToString("dd-MM-yyyy")}.
									
									The overdue payment may result in additional fees or interruption of services. Please make the payment as soon as possible.

									Invoice details:
									- Invoice number: {invoice.InvoiceNumber}
									- Amount: {invoice.PriceGross:C2}
									- Payment due date: {invoice.PaymentDueDate.ToString("dd-MM-yyyy")}

									If you have any questions, please feel free to contact us.

									Best regards,
									Customer Service Team
									";	

				var sendTo = new EmailAddress(email);

				var message = MailHelper.CreateSingleEmail(sendFrom, sendTo, subject, "", htmlMessage);
				var response = await client.SendEmailAsync(message);
			}

		}
	}
}
