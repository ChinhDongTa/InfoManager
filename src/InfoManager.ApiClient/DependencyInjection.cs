using InfoManager.ApiClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InfoManager.ApiClient;

public static class DependencyInjection
{
    public static IServiceCollection AddApiClient(this IServiceCollection services, string baseUrl)
    {
        // Register the handler
        services.AddTransient<JwtAuthorizationMessageHandler>();

        // ==================== IAuthApi (NO auth handler!) ====================
        services.AddRefitGeneratedClient<IAuthApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
        // ISelectListApi stays without auth handler (as you had)
        //services.AddRefitGeneratedClient<ISelectListApi>()
        //    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
        // ← Do NOT add JwtAuthorizationMessageHandler here

        // ==================== Authenticated APIs ====================
        void AddAuthenticatedClient<T>() where T : class
        {
            services.AddRefitGeneratedClient<T>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl))
                .AddHttpMessageHandler(sp => sp.GetRequiredService<JwtAuthorizationMessageHandler>());
        }
        AddAuthenticatedClient<ICategoryApi>();
        AddAuthenticatedClient<IExperienceApi>();
        AddAuthenticatedClient<IFamilyApi>();
        AddAuthenticatedClient<IHistoricalEventApi>();
        AddAuthenticatedClient<IIdentityApi>();
        AddAuthenticatedClient<IIntentionApi>();
        AddAuthenticatedClient<IPriceTrackingApi>();
        AddAuthenticatedClient<ITransactionApi>();
        AddAuthenticatedClient<IProtectAuthApi>();
        AddAuthenticatedClient<IFamilyEventOccurrenceApi>();
        AddAuthenticatedClient<IFamilyEventReminderApi>();
        AddAuthenticatedClient<IUserProfileApi>();
        AddAuthenticatedClient<ISocialAccountApi>();
        AddAuthenticatedClient<IAgriculturalApi>();
        AddAuthenticatedClient<ICustomerApi>();
        AddAuthenticatedClient<IDeviceAlertApi>();
        AddAuthenticatedClient<IDeviceApi>();
        AddAuthenticatedClient<IFarmApi>();
        AddAuthenticatedClient<IFarmerApi>();
        AddAuthenticatedClient<IFieldApi>();
        AddAuthenticatedClient<ISensorApi>();
        AddAuthenticatedClient<IEquipmentApi>();
        AddAuthenticatedClient<IFertilizationPlanApi>();
        AddAuthenticatedClient<IFertilizerApi>();
        AddAuthenticatedClient<IFertilizerApplicationApi>();
        AddAuthenticatedClient<IPesticideApi>();
        AddAuthenticatedClient<IPesticideApplicationApi>();
        AddAuthenticatedClient<IPesticidePlanApi>();
        AddAuthenticatedClient<ICropCycleApi>();
        AddAuthenticatedClient<IHarvestPlanApi>();
        AddAuthenticatedClient<IPlantingPlanApi>();
        AddAuthenticatedClient<IDepartmentApi>();
        AddAuthenticatedClient<IEmployeeAttendanceApi>();
        AddAuthenticatedClient<IEmployeeContractApi>();
        AddAuthenticatedClient<IHREmployeeApi>();
        AddAuthenticatedClient<IJobAssignmentApi>();
        AddAuthenticatedClient<IJobPositionApi>();
        AddAuthenticatedClient<ILeaveRequestApi>();
        AddAuthenticatedClient<IPayrollApi>();
        AddAuthenticatedClient<IWorkShiftApi>();
        AddAuthenticatedClient<ICostAnalysisApi>();
        AddAuthenticatedClient<IFarmExpenseApi>();
        AddAuthenticatedClient<IFarmFinancialSummaryApi>();
        AddAuthenticatedClient<IFarmRevenueApi>();

        //====================== Services ======================
        services.AddScoped<IExperienceService, ExperienceService>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFamilyService, FamilyService>();
        services.AddScoped<IHistoricalEventService, HistoricalEventService>();
        services.AddScoped<IIntentionService, IntentionService>();
        services.AddScoped<IPriceTrackingService, PriceTrackingService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IFamilyEventReminderService, FamilyEventReminderService>();
        services.AddScoped<IFamilyEventOccurrenceService, FamilyEventOccurrenceService>();
        services.AddScoped<IUserProfileService, UserProfileService>();
        services.AddScoped<ISocialAccountService, SocialAccountService>();
        services.AddScoped<IAgriculturalService, AgriculturalService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IDeviceAlertService, DeviceAlertService>();
        services.AddScoped<IDeviceService, DeviceService>();
        services.AddScoped<IFarmService, FarmService>();
        services.AddScoped<IFarmerService, FarmerService>();
        services.AddScoped<IFieldService, FieldService>();
        services.AddScoped<ISensorService, SensorService>();
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<IFertilizationPlanService, FertilizationPlanService>();
        services.AddScoped<IFertilizerService, FertilizerService>();
        services.AddScoped<IFertilizerApplicationService, FertilizerApplicationService>();
        services.AddScoped<IPesticideService, PesticideService>();
        services.AddScoped<IPesticideApplicationService, PesticideApplicationService>();
        services.AddScoped<IPesticidePlanService, PesticidePlanService>();
        services.AddScoped<ICropCycleService, CropCycleService>();
        services.AddScoped<IHarvestPlanService, HarvestPlanService>();
        services.AddScoped<IPlantingPlanService, PlantingPlanService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IEmployeeAttendanceService, EmployeeAttendanceService>();
        services.AddScoped<IEmployeeContractService, EmployeeContractService>();
        services.AddScoped<IHREmployeeService, HREmployeeService>();
        services.AddScoped<IJobAssignmentService, JobAssignmentService>();
        services.AddScoped<IJobPositionService, JobPositionService>();
        services.AddScoped<ILeaveRequestService, LeaveRequestService>();
        services.AddScoped<IPayrollService, PayrollService>();
        services.AddScoped<IWorkShiftService, WorkShiftService>();
        services.AddScoped<ICostAnalysisService, CostAnalysisService>();
        services.AddScoped<IFarmExpenseService, FarmExpenseService>();
        services.AddScoped<IFarmFinancialSummaryService, FarmFinancialSummaryService>();
        services.AddScoped<IFarmRevenueService, FarmRevenueService>();

        return services;
    }
}