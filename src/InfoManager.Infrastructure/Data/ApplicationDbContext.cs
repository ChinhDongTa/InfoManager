using InfoManager.Application.Common.Handlers;
using InfoManager.Application.Common.Interfaces;
using InfoManager.Domain.Common;
using InfoManager.Infrastructure.Data.Converters;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace InfoManager.Infrastructure.Data;

//public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUser? user) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    private readonly IUser? _user = user;

    public DbSet<Experience> Experiences =>Set<Experience>();
    public DbSet<FamilyEvent> FamilyEvents =>Set<FamilyEvent>();
    public DbSet<FamilyMember> FamilyMembers =>Set<FamilyMember>();
    public DbSet<FamilyRelation> FamilyRelations =>Set<FamilyRelation>();
    public DbSet<HistoricalEvent> HistoricalEvents =>Set<HistoricalEvent>();
    public DbSet<Intention> Intentions =>Set<Intention>();
    public DbSet<PriceTracking> PriceTrackings =>Set<PriceTracking>();
    public DbSet<TokenBlacklist> TokenBlacklists =>Set<TokenBlacklist>();
    public DbSet<Transaction> Transactions =>Set<Transaction>();
    public DbSet<Category> Categories =>Set<Category>();
    public IQueryable<T> SqlQueryRaw<T>(string sql, params object[] parameters) where T : class
    {
        return Database.SqlQueryRaw<T>(sql, parameters);
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=InfoManagerDb; Username=postgres; Password=P@ssw0rd");
    //}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Configure UTC converters for all DateTimeOffset properties to ensure PostgreSQL compatibility
        // PostgreSQL's 'timestamp with time zone' only accepts UTC offset (offset 0)
        ConfigureDateTimeOffsetConverters(builder);

        // Apply global query filter for user-based data access
        ApplyGlobalQueryFilters(builder);

        //Seed data
       Seeds.SeedData(builder);
    }

    /// <summary>
    /// Applies UTC converters to all DateTimeOffset properties in the model.
    /// This ensures that all timestamps are stored in UTC in the database, avoiding
    /// PostgreSQL's "only offset 0 (UTC) is supported" error.
    /// </summary>
    private static void ConfigureDateTimeOffsetConverters(ModelBuilder builder)
    {
        var dateTimeOffsetUtcConverter = new DateTimeOffsetUtcConverter();
        var nullableDateTimeOffsetUtcConverter = new NullableDateTimeOffsetUtcConverter();

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTimeOffset))
                {
                    property.SetValueConverter(dateTimeOffsetUtcConverter);
                }
                else if (property.ClrType == typeof(DateTimeOffset?))
                {
                    property.SetValueConverter(nullableDateTimeOffsetUtcConverter);
                }
            }
        }
    }

    /// <summary>
    /// Applies global query filters to automatically filter data based on the current user.
    /// All BaseAuditableEntity types will only return records created by the current user.
    /// If no user is authenticated (user.Id is null), all records are returned.
    /// </summary>
    private void ApplyGlobalQueryFilters(ModelBuilder builder)
    {
        var currentUserId = _user?.Id;
        var currentUserRoles = _user?.Roles ?? [];

        // Nếu user có role bypass filter thì không áp dụng
        var bypassRoles = new[] { "admin", "superuser" };
        if (currentUserRoles.Intersect(bypassRoles).Any())
            return;
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            // Check if entity inherits from BaseAuditableEntity by checking if it has CreatedBy property
            if (((entityType.ClrType.IsAssignableTo(typeof(BaseAuditableEntity))
                 && !entityType.ClrType.IsAssignableTo(typeof(BaseEntity)))
                 || entityType.ClrType.BaseType == typeof(BaseAuditableEntity)) 
                 && !string.IsNullOrEmpty(currentUserId))
            {
                // Get the generic parameter for the lambda expression
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var createdByProperty = Expression.Property(parameter, "CreatedBy");
                var constant = Expression.Constant(currentUserId);
                var equalExpression = Expression.Equal(createdByProperty, constant);
                var lambda = Expression.Lambda(equalExpression, parameter);
                entityType.SetQueryFilter(lambda);
            }
        }
    }
}