using Cards.Application.Contracts.Identity;
using Cards.Application.Contracts.Services;
using Cards.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cards.Identity.Models
{
	public class JwtTokenGenerator : IJwtTokenGenerator
	{
		private readonly IDatetimeProvider _dateTimeProvider;
		private readonly JwtSettings _jwtSettings;

		public JwtTokenGenerator(IDatetimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
		{
			_jwtSettings = jwtOptions.Value;
			_dateTimeProvider = dateTimeProvider;
		}

		public string GenerateToken(User user)
		{
			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
				SecurityAlgorithms.HmacSha256
			);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			claims.Add(new Claim(ClaimTypes.Role, user.Role));

			var securityToken = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
				claims: claims,
				signingCredentials: signingCredentials);

			return new JwtSecurityTokenHandler().WriteToken(securityToken);
		}
	}
}
