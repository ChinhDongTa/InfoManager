using InfoManager.Application.Common.Interfaces;
using InfoManager.Infrastructure.Data;
using InfoManager.Infrastructure.Data.Email;
using InfoManager.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InfoManager.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Host=localhost;Port=5432;Database=InfoManagerDb; Username=postgres; Password=P@ssw0rd";

        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
       builder.Services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString);
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        });

        builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        builder.Services.AddSingleton(TimeProvider.System);
        builder.Services.AddScoped<IEmailSender, MimeKitEmailSender>();
    }
}