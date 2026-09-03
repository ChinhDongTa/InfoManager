namespace InfoManager.Infrastructure.Data.Configurations;

public class SocialAccountConfiguration : IEntityTypeConfiguration<SocialAccount>
{
    public void Configure(EntityTypeBuilder<SocialAccount> builder)
    {
        builder.HasOne(x => x.User)
               .WithMany()                                      // hoặc .WithMany(u => u.SocialAccounts)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        // Một user không được trùng Provider
        builder.HasIndex(x => new { x.UserId, x.Provider })
               .IsUnique();

        // Rất quan trọng cho bot: tìm user theo TelegramId / ZaloId...
        builder.HasIndex(x => new { x.Provider, x.ProviderAccountId })
               .IsUnique();                                     // mỗi ProviderAccountId là duy nhất trên hệ thống

        builder.Property(x => x.Provider).HasMaxLength(50).IsRequired();
        builder.Property(x => x.ProviderAccountId).HasMaxLength(100).IsRequired();
    }
}