using Cards.Application.Contracts;
using Cards.Domain.Common;
using Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cards.Persistence
{
	public class CardsDbContext : DbContext
	{
		private readonly ILoggedInUserService? _loggedInUserService;

		public CardsDbContext(DbContextOptions<CardsDbContext> options)
			: base(options)
		{
		}

		public CardsDbContext(DbContextOptions<CardsDbContext> options, ILoggedInUserService loggedInUserService)
			: base(options)
		{
			_loggedInUserService = loggedInUserService;
		}

		public DbSet<Card> Cards { get; set; }

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardsDbContext).Assembly);

			var adminUser = new User()
			{
				UserId = Guid.Parse("{7d558b50-4718-453f-bede-4465e9a2dd37}"),
				Email = "koutlasilias@gmail.com",
				Password = "rita@4",
				Role = "Administrator"
			};

			var memberUser = new User()
			{
				UserId = Guid.Parse("{3637dd46-f4f2-46cd-bbe4-3a3860d4a215}"),
				Email = "pohiosm@gmail.com",
				Password = "rita@5",
				Role = "Member"
			};

			modelBuilder.Entity<User>().HasData(adminUser);
			modelBuilder.Entity<User>().HasData(memberUser);

			modelBuilder.Entity<Card>().HasData(new Card
			{
				UserId = adminUser.UserId,
				CardId = Guid.Parse("{5441c11c-22b5-4b74-9ccb-3834e68a30ec}"),
				Name = "Clean the house",
				Color = "#ff5733",
				CreatedDate = DateTime.Now,
				CreatedBy = adminUser.UserId.ToString(),
			});

			modelBuilder.Entity<Card>().HasData(new Card
			{
				UserId = adminUser.UserId,
				CardId = Guid.Parse("{1e0d9474-499e-4be5-a295-e6c130f9aa6e}"),
				Name = "Buy food for the cat",
				Color = "#7aff33",
				CreatedDate = DateTime.Now,
				CreatedBy = adminUser.UserId.ToString(),
			});

			modelBuilder.Entity<Card>().HasData(new Card
			{
				UserId = memberUser.UserId,
				CardId = Guid.Parse("{0faed4dd-dc36-4d16-aa2c-c4bce45f27e6}"),
				Name = "Throw garbage",
				Color = "#7aff33",
				CreatedDate = DateTime.Now,
				CreatedBy = memberUser.UserId.ToString(),
			});
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreatedDate = DateTime.Now;
						entry.Entity.CreatedBy = _loggedInUserService.UserId;
						break;
					case EntityState.Modified:
						entry.Entity.LastModifiedDate = DateTime.Now;
						entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
						break;
				}
			}
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
