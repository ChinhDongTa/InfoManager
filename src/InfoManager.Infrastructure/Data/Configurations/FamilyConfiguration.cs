using InfoManager.Domain.Entities.Personal;

namespace InfoManager.Infrastructure.Data.Configurations;

public class FamilyConfiguration : IEntityTypeConfiguration<Family>
{
    public void Configure(EntityTypeBuilder<Family> builder)
    {
        builder.HasOne(f => f.Representative)
               .WithMany()                              // Một người có thể làm đại diện (thường chỉ 1 family)
               .HasForeignKey(f => f.RepresentativeId)
               .OnDelete(DeleteBehavior.SetNull);       // Khi xóa member thì chỉ set null, không cascade

        builder.HasMany(f => f.Members)
               .WithOne(m => m.Family)
               .HasForeignKey(m => m.FamilyId)
               .OnDelete(DeleteBehavior.Restrict);      // hoặc Cascade tùy nghiệp vụ
    }
}