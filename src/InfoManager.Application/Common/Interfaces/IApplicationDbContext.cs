using InfoManager.Domain.Entities.SFMS.Operations;

namespace InfoManager.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    //=============================Dùng cho cá nhân, fillter qua userId=CreatedBy =========================
    DbSet<Experience> Experiences { get; }
    DbSet<Intention> Intentions { get; }
    DbSet<PriceTracking> PriceTrackings { get; }
    DbSet<Transaction> Transactions { get; }
    DbSet<UserProfile> UserProfiles { get; }
    DbSet<SocialAccount> SocialAccounts { get; }

    //=============================Dùng cho gia đình, fillter qua familyId=_currentFamilyId ==========================
    DbSet<Family> Families { get; }
    DbSet<FamilyEvent> FamilyEvents { get; }
    DbSet<FamilyMember> FamilyMembers { get; }
    DbSet<FamilyEventOccurrence> FamilyEventOccurrences { get; }
    DbSet<FamilyEventReminder> FamilyEventReminders { get; }

    //=============================Dùng cho amin=========================
    DbSet<TokenBlacklist> TokenBlacklists { get; }
    DbSet<LoginHistory> LoginHistories { get; }

    //=============================Dùng chung=========================
    DbSet<FamilyRelation> FamilyRelations { get; }
    DbSet<HistoricalEvent> HistoricalEvents { get; }
    DbSet<Category> Categories { get; }

    //=============================Dùng cho SFMS (Smart Farm Management System)=========================
    // Customers
    DbSet<Customer> Customers { get; }
    DbSet<CustomerPayment> CustomerPayments { get; }
    DbSet<CustomerCare> CustomerCares { get; }

    // Infrastructure
    DbSet<Farm> Farms { get; }
    DbSet<Field> Fields { get; }
    DbSet<Sensor> Sensors { get; }
    DbSet<Device> Devices { get; }
    DbSet<Farmer> Farmers { get; }
    DbSet<DeviceAlert> DeviceAlerts { get; }
    DbSet<Equipment> Equipments { get; }

    // Agricultural
    DbSet<Crop> Crops { get; }
    DbSet<CropVariety> CropVarieties { get; }
    DbSet<CropSchedule> CropSchedules { get; }
    DbSet<CropPlanting> CropPlantings { get; }
    DbSet<GrowthStage> GrowthStages { get; }
    DbSet<GrowthStageAlert> GrowthStageAlerts { get; }

    // Monitoring
    DbSet<EnvironmentalReading> EnvironmentalReadings { get; }
    DbSet<SoilAnalysis> SoilAnalyses { get; }
    DbSet<CropHealth> CropHealthRecords { get; }

    // Operations
   
    DbSet<Maintenance> MaintenanceRecords { get; }
    DbSet<Domain.Entities.SFMS.Operations.Task> Tasks { get; }

    // Production
    DbSet<Harvest> Harvests { get; }
    DbSet<Product> Products { get; }
    DbSet<Sale> Sales { get; }
    DbSet<Yield> Yields { get; }

    // Issues
    DbSet<Pest> Pests { get; }
    DbSet<Disease> Diseases { get; }
    DbSet<PestDiseaseLink> PestDiseaseLinks { get; }
    DbSet<Infestation> Infestations { get; }

    // Resources
    DbSet<Fertilizer> Fertilizers { get; }
    DbSet<FertilizationPlan> FertilizationPlans { get; }
    DbSet<FertilizerApplication> FertilizerApplications { get; }

    DbSet<Pesticide> Pesticides { get; }
    DbSet<PesticidePlan> PesticidePlans { get; }
    DbSet<PesticideApplication> PesticideApplications { get; }

    //Inventory
    DbSet<FarmInventory> FarmInventories { get; }
    DbSet<InventoryAlert> InventoryAlerts { get; }
    DbSet<InventoryAlertSetting> InventoryAlertSettings { get; }
    DbSet<InventoryReceipt> InventoryReceipts { get; }
    DbSet<InventoryReceiptItem> InventoryReceiptItems { get; }
    DbSet<InventoryTransaction> InventoryTransactions { get; }

    // Weather
    DbSet<WeatherData> WeatherData { get; }
    DbSet<WeatherForecast> WeatherForecasts { get; }
    DbSet<WeatherAlert> WeatherAlerts { get; }

    // Planning
    DbSet<CropCycle> CropCycles { get; }
    DbSet<PlantingPlan> PlantingPlans { get; }
    DbSet<HarvestPlan> HarvestPlans { get; }

    // Economics
    DbSet<FarmExpense> FarmExpenses { get; }
    DbSet<FarmRevenue> FarmRevenues { get; }
    DbSet<CostAnalysis> CostAnalyses { get; }
    DbSet<FarmFinancialSummary> FarmFinancialSummaries { get; }

    // Human Resources
    DbSet<Department> Departments { get; }
    DbSet<JobPosition> JobPositions { get; }
    DbSet<HREmployee> HREmployees { get; }
    DbSet<JobAssignment> JobAssignments { get; }
    DbSet<EmployeeAttendance> EmployeeAttendances { get; }
    DbSet<WorkShift> WorkShifts { get; }
    DbSet<LeaveRequest> LeaveRequests { get; }
    DbSet<EmployeeContract> EmployeeContracts { get; }
    DbSet<Payroll> Payrolls { get; }
    

    IQueryable<T> SqlQueryRaw<T>(string sql, params object[] parameters) where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}