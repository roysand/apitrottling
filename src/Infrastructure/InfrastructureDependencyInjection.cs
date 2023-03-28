using ApiTrottling.Application.Common.Interfaces;
using ApiTrottling.Infrastructure.Persistence;
using ApiTrottling.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTrottling.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IConfig, Config.Config>();
        services.AddTransient<ApplicationDbContext>();
        services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
        
        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }
}
