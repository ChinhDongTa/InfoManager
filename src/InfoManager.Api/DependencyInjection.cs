using InfoManager.Api.Services;
using InfoManager.Application.Common.Services;
using InfoManager.Domain.Entities.Authentication;
using InfoManager.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InfoManager.Api;

public static class DependencyInjection
{
    public static void AddWebServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddScoped<IUser, CurrentUser>();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddExceptionHandler<CustomExceptionHandler>();

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.Converters.Add(
                new System.Text.Json.Serialization.JsonStringEnumConverter()
            );
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });
        // Customise default API behaviour
        builder.Services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "InfoManager API";
            configure.Description = """
                                    InfoManager - Smart Farm Management System

                                    Nhấp vào nút "Authorize" ở trên cùng bên phải để nhập JWT token
                                    """;

            // ✅ Thêm JWT Bearer security scheme
            configure.AddSecurity("Bearer", new NSwag.OpenApiSecurityScheme
            {
                Type = NSwag.OpenApiSecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Name = "Authorization",
                In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                Description = """
                              Nhập JWT token.

                              Cách lấy token:
                              1. Gọi endpoint POST /auth/login với credentials
                              2. Sao chép token từ response
                              3. Dán vào ô Authorization ở đây với tiền tố "Bearer "

                              Ví dụ: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
                              """
            });

            // ✅ Áp dụng security requirement cho tất cả operations
            configure.OperationProcessors.Add(
                new NSwag.Generation.Processors.Security.AspNetCoreOperationSecurityScopeProcessor("Bearer"));
        });

        builder.Services.AddAuthentication()
           .AddBearerToken(IdentityConstants.BearerScheme);

        builder.Services.AddAuthorizationBuilder();

        builder.Services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        builder.Services.AddTransient<IIdentityService, IdentityService>();
        // Đăng ký Authentication với JWT Bearer
        AddJwtAuthentication(builder);
    }

    public static void AddJwtAuthentication(this IHostApplicationBuilder builder)
    {
        // ✅ JWT Configuration
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"] ?? "your-secret-key-here");

        builder.Services.AddAuthentication(options =>
        {
            // ✅ Default: JWT (cho API calls)
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            // ✅ Cookie scheme (fallback)
            options.AddScheme<CookieAuthenticationHandler>("Cookie", "Cookie");
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            //options.Events = new JwtBearerEvents
            //{
            //    OnTokenValidated = async context =>
            //    {
            //        var jti = context.Principal.FindFirstValue(JwtRegisteredClaimNames.Jti);
            //        var userId =context.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            //        var blacklistService = context.HttpContext.RequestServices.GetRequiredService<ITokenBlacklistService>();

            //        if (await blacklistService.IsBlacklistedAsync(jti!, userId!))
            //        {
            //            context.Fail("Token has been revoked.");
            //        }
            //    }
            //};
        })
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
            // ✅ Support cookie-based clients (PC apps)
            options.LoginPath = "api/IdentityJwt/login";
            options.LogoutPath = "api/IdentityJwt/logout";
        });
        builder.Services.AddAuthorization();
    }
}