using InfoManager.ApiClient;
using InfoManager.ApiClient.Abstractions;
using InfoManager.ApiClient.Interfaces;
using InfoManager.Web.Models;
using InfoManager.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace InfoManager.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddBlazorServices(this IServiceCollection services, IConfiguration configuration)
    {
        var hostAddress = configuration["ApiBaseUrl"] ?? "https://localhost:7217";
        services.AddApiClient(hostAddress);
      
        services.AddHttpClient(Constants.PublicHttpClient, client =>
        {
            client.BaseAddress = new Uri(hostAddress);
        });

        services.AddScoped<ITokenStorage, TokenStorage>();
        // Vì AuthService liên quan đến CustomAuthStateProvider nên phải thực hiện nó ở ngay Blazor.
        services.AddScoped<IAuthService, AuthService>();

        


        // Register CustomAuthStateProvider - CRITICAL
        services.AddScoped<CustomAuthStateProvider>();

        // Register as AuthenticationStateProvider so CascadingAuthenticationState uses it
        services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());
        
       
        return services;
    }
}
//https://localhost:7217
//http://localhost:5200


