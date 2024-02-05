using Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cards.Persistence.Configurations
{
	public class CardConfiguration : IEntityTypeConfiguration<Card>
	{
		public void Configure(EntityTypeBuilder<Card> builder)
		{
			builder.Property(c => c.Name)
				.IsRequired();
		}
	}
}
