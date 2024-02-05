using Cards.Application.Models.Mail;

namespace Cards.Application.Contracts.Infrastructure
{
	public interface IEmailService
	{
		Task<bool> SendEmailAsync(Email email);
	}
}
