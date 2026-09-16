using InfoManager.Domain.Entities.SFMS.Infrastructure;

namespace InfoManager.Infrastructure.Data.Configurations.SFMS;

public class FarmerConfiguration : IEntityTypeConfiguration<Farmer>
{
    public void Configure(EntityTypeBuilder<Farmer> builder)
    {
        builder.ToTable("Farmers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasMaxLength(450);

        builder.Property(x => x.FamilyMemberId)
            .HasMaxLength(450);

        builder.Property(x => x.FarmerCode)
            .HasMaxLength(50);

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Phone).HasMaxLength(20);
        builder.Property(x => x.Email).HasMaxLength(200);
        builder.Property(x => x.IdentityNumber).HasMaxLength(50);
        builder.Property(x => x.Address).HasMaxLength(500);
        builder.Property(x => x.Notes).HasMaxLength(500);

        builder.HasIndex(x => x.UserId).IsUnique();
        builder.HasIndex(x => x.FarmerCode);
        builder.HasIndex(x => x.IdentityNumber);
        builder.HasIndex(x => x.Phone);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.FamilyMember)
            .WithMany()
            .HasForeignKey(x => x.FamilyMemberId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Farms)
            .WithOne(x => x.Farmer)
            .HasForeignKey(x => x.FarmerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class FarmConfiguration : IEntityTypeConfiguration<Farm>
{
    public void Configure(EntityTypeBuilder<Farm> builder)
    {
        builder.ToTable("Farms");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Location).HasMaxLength(500);
        builder.Property(x => x.LicenseNumber).HasMaxLength(100);

        builder.Property(x => x.TotalArea).HasPrecision(18, 4);
        builder.Property(x => x.CultivableArea).HasPrecision(18, 4);
        builder.Property(x => x.Latitude).HasPrecision(18, 8);
        builder.Property(x => x.Longitude).HasPrecision(18, 8);

        builder.Property(x => x.FarmerId)
            .IsRequired()
            .HasMaxLength(450);

        builder.Property(x => x.Status)
            .HasConversion<int>();

        builder.HasIndex(x => x.FarmerId);
        builder.HasIndex(x => x.Name);
        builder.HasIndex(x => x.LicenseNumber);
        builder.HasIndex(x => x.Status);

        builder.HasOne(x => x.Farmer)
            .WithMany(x => x.Farms)
            .HasForeignKey(x => x.FarmerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Employees)
            .WithOne(x => x.Farm)
            .HasForeignKey(x => x.FarmId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}