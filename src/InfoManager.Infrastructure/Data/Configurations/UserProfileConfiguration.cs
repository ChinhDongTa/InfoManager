using InfoManager.Domain.Entities.Authentication;

namespace InfoManager.Infrastructure.Data.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        // ====================== 1-1 với ApplicationUser ======================
        builder.HasOne(p => p.User)
               .WithOne()                              // Nếu sau này thêm navigation ở User thì đổi thành .WithOne(u => u.Profile)
               .HasForeignKey<UserProfile>(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.UserId)
               .IsUnique();

        // ====================== 1-1 với FamilyMember ======================
        builder.HasOne(p => p.FamilyMember)
               .WithOne()
               .HasForeignKey<UserProfile>(p => p.FamilyMemberId)
               .OnDelete(DeleteBehavior.SetNull);

        // Unique nhưng cho phép nhiều record null
        builder.HasIndex(p => p.FamilyMemberId)
               .IsUnique()
               .HasFilter("\"FamilyMemberId\" IS NOT NULL");   // PostgreSQL

        // ====================== n-1 với Family ======================
        builder.HasOne(p => p.Family)
               .WithMany()
               .HasForeignKey(p => p.FamilyId)
               .OnDelete(DeleteBehavior.SetNull);


        // Index cho FamilyId (rất quan trọng cho global filter)
        builder.HasIndex(p => p.FamilyId);

        // ====================== Các cấu hình thêm (khuyến nghị) ======================
        builder.Property(p => p.Notes)
               .HasMaxLength(200);

        // Nếu muốn bắt buộc UserId
        builder.Property(p => p.UserId)
               .IsRequired();
    }
}
