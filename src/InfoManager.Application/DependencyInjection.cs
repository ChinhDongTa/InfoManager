using InfoManager.Application.Common.Behaviours;
using InfoManager.Application.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace InfoManager.Application;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.Lifetime = ServiceLifetime.Scoped;
            cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzk4NTg4ODAwIiwiaWF0IjoiMTc2NzA2NTE5MyIsImFjY291bnRfaWQiOiIwMTliNmQ0YTAzOTU3MTBjYjliOTE2NDU4YjJiNzhkNCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa2RwbXAyeWF3ejFtMWt3ZmFtd3l2cWNrIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.Co78aub7TKOHBmrgJtz4Tllu2yc96dgmG6ofDxRqDXopO3zSkYI1C6-HvAzuQvzXhY4vJWqu_yCxwlJ2oAVGV6wcUGe_4rQia1thJ4kyC0xIlxgsRZ8B1ni62GkKNy1UFc2GFfo8jnAR8hjxoeiff6EECCKOucDvE_9UH2BAUqj55mhCzqS75I-XE5cxv1TeTk9Ec_8zkST3L9eaKGCM56-surTOHJW9H_zMVqxpJml8IoeY-18m4Ai6Zxhv5tGLlnWREVSb24TIvSxTBKb-dbSv0u9dCR_xiQ3IW-i5Mu_z8l0mkdUKD-WJvaqAu9xNjGC1XuoOA_kX1HVFANt5lg";
            cfg.AddOpenRequestPreProcessor(typeof(LoggingBehaviour<>));
            cfg.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            cfg.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
        });
        builder.Services.AddScoped<ITokenBlacklistService, TokenBlacklistService>();
        builder.Services.AddScoped<ICodeGeneratorService, CodeGeneratorService>();
    }
}