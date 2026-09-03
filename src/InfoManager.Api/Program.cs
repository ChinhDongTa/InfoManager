using InfoManager.Api;
using InfoManager.Application;
using InfoManager.Infrastructure;
using NSwag;
using NSwag.Generation.Processors.Security;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.AddInfrastructureServices();
builder.AddApplicationServices();
builder.AddWebServices();

//Dùng để xem chi tiết lổi
//builder.Services.AddExceptionHandler(options =>
//{
//    options.AllowStatusCode404Response = true;
//});

//using var loggerFactory = LoggerFactory.Create(config => config.AddConsole());
//var startupLogger = loggerFactory.CreateLogger<Program>();

//startupLogger.LogInformation("Starting web host");

// ================== BOOTSTRAP LOGGER ==================
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(
        theme: AnsiConsoleTheme.Code,           // ← Dùng theme có màu
        applyThemeToRedirectedOutput: true      // ← Rất quan trọng khi chạy Aspire
    )
    .CreateBootstrapLogger();   // Dùng bootstrap logger

// ================== CẤU HÌNH SERILOG CHÍNH ==================
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console(
            theme: AnsiConsoleTheme.Code,
            applyThemeToRedirectedOutput: true,
            outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
        );
});

var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();   // ← thêm dòng này
//}

Log.Information("Application built successfully");


app.UseExceptionHandler(options => {});

// ✅ Use CORS middleware
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.UseHttpsRedirection();



app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();

