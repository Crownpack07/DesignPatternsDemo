using DesignPatternsDemo.Domain.Vat;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatternsDemo.Infrastructure.Vat;

public static class RegisterVatInfrastructure
{
    public static IServiceCollection RegisterVat(this IServiceCollection services)
    {
        //Register Local Repository
        // services.AddSingleton<IVatRepository, VatLocalRepository>();
        //Register Mongo
        services.AddSingleton<IVatRepository, VatMongoRepository>();

        return services;
    }
}