using Cards.API.Middleware;
using Cards.API.Services;
using Cards.Application;
using Cards.Application.Contracts;
using Cards.Infrastructure;
using Cards.Persistence;
using Cards.Identity;
using Microsoft.EntityFrameworkCore;
using Cards.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Cards.API
{
	public static class StartupExtensions
	{
		public static WebApplication ConfigureServices(
			this WebApplicationBuilder builder)
		{
			builder.Services.AddPresentationServices();
			builder.Services.AddApplicationServices();
			builder.Services.AddInfrastructureServices(builder.Configuration);
			builder.Services.AddPersistenceServices(builder.Configuration);
			builder.Services.AddIdentityServices(builder.Configuration);

			builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

			builder.Services.AddCors(
				options => options.AddPolicy(
					"open",
					policy => policy.WithOrigins([builder.Configuration["ApiUrl"] ?? "https://localhost:7081",
						builder.Configuration["BlazorUrl"] ?? "https://localhost:7080"])
			.AllowAnyMethod()
			.SetIsOriginAllowed(pol => true)
			.AllowAnyHeader()
			.AllowCredentials()));

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options =>
			{
				options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
				{
					Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
					In = ParameterLocation.Header,
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});

				options.OperationFilter<SecurityRequirementsOperationFilter>();
			});

			return builder.Build();
		}

		public static WebApplication ConfigurePipeline(this WebApplication app)
		{
			//app.MapIdentityApi<ApplicationUser>();

			//app.MapPost("/Logout", async (ClaimsPrincipal user, SignInManager<ApplicationUser> signInManager) =>
			//{
			//	await signInManager.SignOutAsync();
			//	return TypedResults.Ok();
			//});

			app.UseCors("open");

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCustomExceptionHandler();

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();

			return app;
		}

		public static async Task ResetDatabaseAsync(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			try
			{
				var context = scope.ServiceProvider.GetService<CardsDbContext>();
				if (context != null)
				{
					await context.Database.EnsureDeletedAsync();
					await context.Database.MigrateAsync();
				}
			}
			catch (Exception ex)
			{
				//TODO: add logging
			}
		}
	}
}
