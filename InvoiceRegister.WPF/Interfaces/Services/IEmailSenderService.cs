﻿using InvoiceRegister.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceRegister.WPF.Interfaces.Services
{
    public interface IEmailSenderService
	{
		// Sends email to all clients with overdue payments
		Task SendWarningEmailsAsync(List<OverdueInvoiceVM> overdueInvoices);
    }
}
