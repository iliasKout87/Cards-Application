using Cards.Application.Contracts.Identity;
using Cards.Identity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Cards.Identity
{
	public static class IdentityServiceExtensions
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
		{
			var JwtSettings = new JwtSettings();
			configuration.Bind(JwtSettings.SectionName, JwtSettings);

			services.AddSingleton(Options.Create(JwtSettings));
			services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

			services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = JwtSettings.Issuer,
					ValidAudience = JwtSettings.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret))
				});

			return services;
		}
	}
}
