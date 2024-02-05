using Cards.Application.Contracts.Infrastructure;
using Cards.Application.Models.Mail;
using Cards.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

			services.AddTransient<IEmailService, EmailService>();

			return services;
		}
	}
}
