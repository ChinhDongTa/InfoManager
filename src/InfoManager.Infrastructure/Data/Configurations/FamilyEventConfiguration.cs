using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Infrastructure.Data.Configurations;

public class FamilyEventConfiguration : IEntityTypeConfiguration<FamilyEvent>
{
    public void Configure(EntityTypeBuilder<FamilyEvent> builder)
    {
        builder.HasIndex(e => new { e.FamilyMemberId, e.EventType })
               .IsUnique();
    }
}
