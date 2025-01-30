using Azure.Core;
using InvoiceRegister.WPF.Interfaces.Services;
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
/*		private readonly string sendGridConnectionString;
		private readonly string sendFromEmailAddress;

		public EmailSenderService(string sendGridConnectionString, string sendFromEmailAddress)
		{
			this.sendGridConnectionString = sendGridConnectionString;
			this.sendFromEmailAddress = sendFromEmailAddress;
		}*/

		public async Task SendWarningEmailsAsync()
		{
/*			string email = "", subject = "", htmlMessage = "";
			var client = new SendGridClient(sendGridConnectionString);

			var sendFrom = new EmailAddress(sendFromEmailAddress);
			var sendTo = new EmailAddress(email);

			var message = MailHelper.CreateSingleEmail(sendFrom, sendTo, subject, "", htmlMessage);
			var response = await client.SendEmailAsync(message);*/
		}
	}
}
