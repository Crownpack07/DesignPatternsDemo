using DesignPatternsDemo.Infrastructure.Orders;
using DesignPatternsDemo.Infrastructure.Vat;
using DesignPatternsDemo.Kernel.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsDemo.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = new Settings();
        configuration.GetSection(nameof(Settings)).Bind(settings);
        services.Configure<Settings>(configuration.GetSection(nameof(Settings)));
        services
            .RegisterMongoKernel(configuration)
            .RegisterOrders()
            .RegisterVat();

        return services;
    }
}