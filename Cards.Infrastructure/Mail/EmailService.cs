﻿using Cards.Application.Contracts.Infrastructure;
using Cards.Application.Models.Mail;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Options;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Cards.Infrastructure.Mail
{
	public class EmailService : IEmailService
	{
		private readonly EmailSettings _emailSettings;

		public ILogger<EmailService> _logger { get; }


		public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
		{
			_emailSettings = emailSettings.Value;
			_logger = logger;
		}

		public async Task<bool> SendEmailAsync(Email email)
		{
			var client = new SendGridClient(_emailSettings.ApiKey);

			var subject = email.Subject;
			var to = new EmailAddress(email.To);
			var emailBody = email.Body;

			var from = new EmailAddress
			{
				Email = _emailSettings.FromAddress,
				Name = _emailSettings.FromName
			};

			var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
			var response = await client.SendEmailAsync(sendGridMessage);

			_logger.LogInformation("Email sent");

			if (response.StatusCode == HttpStatusCode.Accepted
				|| response.StatusCode == HttpStatusCode.OK
			)
			{
				return true;
			}

			_logger.LogError("Email sending failed");

			return false;
		}
	}
}
