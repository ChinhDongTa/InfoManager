using InfoManager.Application.Common.Interfaces;
using InfoManager.Domain.Entities.Authentication;
using InfoManager.Domain.Entities.Personal;
using InfoManager.Domain.Entities.SFMS.Agricultural;
using InfoManager.Domain.Entities.SFMS.Customers;
using InfoManager.Domain.Entities.SFMS.Economics;
using InfoManager.Domain.Entities.SFMS.HR;
using InfoManager.Domain.Entities.SFMS.Infrastructure;
using InfoManager.Domain.Entities.SFMS.Inventory;
using InfoManager.Domain.Entities.SFMS.Issues;
using InfoManager.Domain.Entities.SFMS.Monitoring;
using InfoManager.Domain.Entities.SFMS.Operations;
using InfoManager.Domain.Entities.SFMS.Planning;
using InfoManager.Domain.Entities.SFMS.Production;
using InfoManager.Domain.Entities.SFMS.Resources;
using InfoManager.Domain.Entities.SFMS.Weather;
using InfoManager.Infrastructure.Data.Converters;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace InfoManager.Infrastructure.Data;

//public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUser? user) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    //User user;
    private readonly string? _currentUserId= user?.Id;

    #region Personal / Family
    //=============================Dùng cho cá nhân, fillter qua userId=CreatedBy =========================
    public DbSet<Experience> Experiences =>Set<Experience>();
    public DbSet<Intention> Intentions => Set<Intention>();
    public DbSet<PriceTracking> PriceTrackings => Set<PriceTracking>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
    public DbSet<SocialAccount> SocialAccounts => Set<SocialAccount>();

    //=============================Dùng cho gia đình, fillter qua familyId=_currentFamilyId ==========================
    public DbSet<Family> Families  =>Set<Family>();
    public DbSet<FamilyEvent> FamilyEvents =>Set<FamilyEvent>();
    public DbSet<FamilyMember> FamilyMembers =>Set<FamilyMember>();
    public DbSet<FamilyEventOccurrence> FamilyEventOccurrences => Set<FamilyEventOccurrence>();
    public DbSet<FamilyEventReminder> FamilyEventReminders => Set<FamilyEventReminder>();
    public DbSet<FamilyRelation> FamilyRelations => Set<FamilyRelation>();
    public DbSet<HistoricalEvent> HistoricalEvents => Set<HistoricalEvent>();
    public DbSet<Category> Categories =>Set<Category>();

    #endregion Personal / Family

    //============================= Dùng cho admin =========================
    public DbSet<TokenBlacklist> TokenBlacklists => Set<TokenBlacklist>();
    public DbSet<LoginHistory> LoginHistories => Set<LoginHistory>();

    #region SFMS (Smart Farm Management System)

    //=============================SFMS (Smart Farm Management System)=========================
    // Customers
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<CustomerPayment> CustomerPayments => Set<CustomerPayment>();
    public DbSet<CustomerCare> CustomerCares => Set<CustomerCare>();

    // Infrastructure
    public DbSet<Farm> Farms => Set<Farm>();
    public DbSet<Farmer> Farmers => Set<Farmer>();
    public DbSet<Field> Fields => Set<Field>();
    public DbSet<Sensor> Sensors => Set<Sensor>();
    public DbSet<Device> Devices => Set<Device>();
    public DbSet<DeviceAlert> DeviceAlerts => Set<DeviceAlert>();

    // Agricultural
    public DbSet<Crop> Crops => Set<Crop>();
    public DbSet<CropVariety> CropVarieties => Set<CropVariety>();
    public DbSet<CropSchedule> CropSchedules => Set<CropSchedule>();
    public DbSet<CropPlanting> CropPlantings => Set<CropPlanting>();
    public DbSet<GrowthStage> GrowthStages => Set<GrowthStage>();
    public DbSet<GrowthStageAlert> GrowthStageAlerts => Set<GrowthStageAlert>();

    // Monitoring
    public DbSet<EnvironmentalReading> EnvironmentalReadings => Set<EnvironmentalReading>();
    public DbSet<SoilAnalysis> SoilAnalyses => Set<SoilAnalysis>();
    public DbSet<CropHealth> CropHealthRecords => Set<CropHealth>();

    // Operations
    public DbSet<Equipment> Equipments => Set<Equipment>();
    public DbSet<Maintenance> MaintenanceRecords => Set<Maintenance>();
    public DbSet<Domain.Entities.SFMS.Operations.Task> Tasks => Set<Domain.Entities.SFMS.Operations.Task>();

    // Production
    public DbSet<Harvest> Harvests => Set<Harvest>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<Yield> Yields => Set<Yield>();

    // Issues
    public DbSet<Pest> Pests => Set<Pest>();
    public DbSet<Disease> Diseases => Set<Disease>();
    public DbSet<PestDiseaseLink> PestDiseaseLinks => Set<PestDiseaseLink>();
    public DbSet<Infestation> Infestations => Set<Infestation>();

    // Resources
    public DbSet<Fertilizer> Fertilizers =>Set<Fertilizer>();
    public DbSet<FertilizationPlan> FertilizationPlans =>Set<FertilizationPlan>();
    public DbSet<FertilizerApplication> FertilizerApplications =>Set<FertilizerApplication>();
    public DbSet<Pesticide> Pesticides=>Set<Pesticide>();
    public DbSet<PesticidePlan> PesticidePlans=>Set<PesticidePlan>();
    public DbSet<PesticideApplication> PesticideApplications =>Set<PesticideApplication>();

    //Inventory
    public DbSet<InventoryAlert> InventoryAlerts=>Set<InventoryAlert>();
    public DbSet<FarmInventory> FarmInventories =>Set<FarmInventory>();
    public DbSet<InventoryAlertSetting> InventoryAlertSettings =>Set<InventoryAlertSetting>();
    public DbSet<InventoryReceipt> InventoryReceipts=>Set<InventoryReceipt>();
    public DbSet<InventoryReceiptItem> InventoryReceiptItems =>Set<InventoryReceiptItem>();
    public DbSet<InventoryTransaction> InventoryTransactions=>Set<InventoryTransaction>();

    // Weather
    public DbSet<WeatherData> WeatherData => Set<WeatherData>();
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
    public DbSet<WeatherAlert> WeatherAlerts => Set<WeatherAlert>();

    // Planning
    public DbSet<CropCycle> CropCycles => Set<CropCycle>();
    public DbSet<PlantingPlan> PlantingPlans => Set<PlantingPlan>();
    public DbSet<HarvestPlan> HarvestPlans => Set<HarvestPlan>();

    // Economics
    public DbSet<FarmExpense> FarmExpenses => Set<FarmExpense>();
    public DbSet<FarmRevenue> FarmRevenues => Set<FarmRevenue>();
    public DbSet<CostAnalysis> CostAnalyses => Set<CostAnalysis>();
    public DbSet<FarmFinancialSummary> FarmFinancialSummaries => Set<FarmFinancialSummary>();

    // Human Resources
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<JobPosition> JobPositions =>Set<JobPosition>();
    public DbSet<HREmployee> HREmployees => Set<HREmployee>();
    public DbSet<JobAssignment> JobAssignments => Set<JobAssignment>();
    public DbSet<EmployeeAttendance> EmployeeAttendances => Set<EmployeeAttendance>();
    public DbSet<WorkShift> WorkShifts=> Set<WorkShift>();
    public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();
    public DbSet<EmployeeContract> EmployeeContracts => Set<EmployeeContract>();
    public DbSet<Payroll> Payrolls => Set<Payroll>();
    #endregion 

    public IQueryable<T> SqlQueryRaw<T>(string sql, params object[] parameters) where T : class
    {
        return Database.SqlQueryRaw<T>(sql, parameters);
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SFMSDb; Username=postgres; Password=P@ssw0rd");
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

    //private string? ResolveFamilyId()
    //{
    //    if (string.IsNullOrEmpty(_currentUserId)) return null;

    //    // Lúc này DbContext đã sẵn sàng (gọi khi query thật sự xảy ra)
    //    return UserProfiles
    //        .AsNoTracking()
    //        .Where(p => p.UserId == _currentUserId)
    //        .Select(p => p.FamilyId)
    //        .FirstOrDefault();
    //}

    /// <summary>
    /// Applies global query filters to automatically filter data based on the current user.
    /// All BaseAuditableEntity types will only return records created by the current user.
    /// If no user is authenticated (user.Id is null), all records are returned.
    /// </summary>
    private void ApplyGlobalQueryFilters(ModelBuilder builder)
    {
        var roles = user?.Roles ?? [];
        //Console.WriteLine("======roles: " + string.Join(", ", roles));
        //// ====================== Admin / SuperUser bỏ qua toàn bộ filter ======================
        //if (roles.Intersect(["admin", "superuser"]).Any())
        //{
        // Console.WriteLine("====Admin/SuperUser detected, skipping global query filters.====");
        //    return;
        //}

        //if (string.IsNullOrEmpty(_currentUserId))
        //{
        // Console.WriteLine("=====No current user ID found, skipping global query filters.====");
        //    return;
        //}

        // ====================== 1. UserProfile (chỉ nhìn thấy profile của chính mình) ======================
        builder.Entity<UserProfile>()
               .HasQueryFilter(p => p.UserId == _currentUserId);
        builder.Entity<SocialAccount>()
               .HasQueryFilter(sa => sa.UserId == _currentUserId);

        // ====================== 2. Dữ liệu CÁ NHÂN (chỉ mình thấy) ======================
        builder.Entity<Intention>()
               .HasQueryFilter(x => x.CreatedBy == _currentUserId);

        builder.Entity<PriceTracking>()
               .HasQueryFilter(x => x.CreatedBy == _currentUserId);

        builder.Entity<Experience>()
               .HasQueryFilter(x => x.CreatedBy == _currentUserId);

        builder.Entity<Transaction>()
               .HasQueryFilter(x => x.CreatedBy == _currentUserId);

        // ====================== 3. Dữ liệu GIA ĐÌNH ======================
        // Nếu user chưa có FamilyId thì không cho xem dữ liệu gia đình
        //if (string.IsNullOrEmpty(CurrentFamilyId))
        //    return;

        // Family
        builder.Entity<Family>()
               .HasQueryFilter(f => f.CreatedBy == _currentUserId);

        // FamilyMember
        builder.Entity<FamilyMember>()
               .HasQueryFilter(m => m.CreatedBy == _currentUserId);

        // FamilyEvent
        builder.Entity<FamilyEvent>()
               .HasQueryFilter(e => e.CreatedBy == _currentUserId);

        // FamilyEventOccurrence
        builder.Entity<FamilyEventOccurrence>()
               .HasQueryFilter(o => o.CreatedBy == _currentUserId);

        // FamilyEventReminder
        builder.Entity<FamilyEventReminder>()
               .HasQueryFilter(r => r.CreatedBy == _currentUserId);

        // FamilyRelation (nếu muốn chia sẻ theo gia đình thì đổi sang FamilyId, hiện giữ theo người tạo)
        //builder.Entity<FamilyRelation>()
        //       .HasQueryFilter(r => r.CreatedBy == _currentUserId);
    }
}