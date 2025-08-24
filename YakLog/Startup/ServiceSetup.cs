using Microsoft.EntityFrameworkCore;
using System;
using YakLog.Application.Services;
using YakLog.Persistence.Repositories;
using YakLogApi.Persistence;
using YakLogApi.Services.Interfaces;

namespace YakLogApi.Startup;

public static class ServiceSetup
{
    public static void AddYaklogServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(IService))
            .AddClasses(classes => classes.AssignableTo<IService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        services.Scan(scan => scan
            .FromAssemblyOf<UserRepository>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );
        services.AddScoped<TokenService>();
    }
}
