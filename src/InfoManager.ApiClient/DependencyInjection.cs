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
        services.AddRefitClient<IAuthApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
        // ISelectListApi stays without auth handler (as you had)
        services.AddRefitClient<ISelectListApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));
        // ← Do NOT add JwtAuthorizationMessageHandler here

        // ==================== Authenticated APIs ====================
        void AddAuthenticatedClient<T>() where T : class
        {
            services.AddRefitClient<T>()
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

        //====================== Services ======================
        services.AddScoped<ISelectListService, SelectListService>();
        services.AddScoped<IExperienceService, ExperienceService>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFamilyService, FamilyService>();
        services.AddScoped<IHistoricalEventService, HistoricalEventService>();
        services.AddScoped<IIntentionService, IntentionService>();
        services.AddScoped<IPriceTrackingService, PriceTrackingService>();
        services.AddScoped<ITransactionService, TransactionService>();

        return services;
    }
}