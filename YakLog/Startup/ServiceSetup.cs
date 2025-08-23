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
    }
}
