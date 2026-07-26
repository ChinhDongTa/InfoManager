namespace InfoManager.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Experience> Experiences { get; }
    DbSet<FamilyEvent> FamilyEvents { get; }
    DbSet<FamilyMember> FamilyMembers { get; }
    DbSet<FamilyRelation> FamilyRelations { get; }
    DbSet<HistoricalEvent> HistoricalEvents { get; }
    DbSet<Intention> Intentions { get; }
    DbSet<PriceTracking> PriceTrackings { get; }
    DbSet<TokenBlacklist> TokenBlacklists { get; }
    DbSet<Transaction> Transactions { get; }
    DbSet<Category> Categories { get; }

    IQueryable<T> SqlQueryRaw<T>(string sql, params object[] parameters) where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}