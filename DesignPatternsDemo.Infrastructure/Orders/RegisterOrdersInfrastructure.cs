using DesignPatternsDemo.Domain.Orders;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;

namespace DesignPatternsDemo.Infrastructure.Orders;

public static class RegisterOrdersInfrastructure
{
    public static IServiceCollection RegisterOrders(this IServiceCollection services)
    {
        //Register Local Repository
        // services.AddSingleton<IOrderRepository, OrderLocalRepository>();
        
        //Register Mongo Repository
        services.AddSingleton<IOrderRepository, OrderMongoRepository>();

        RegisterClassMaps();
        
        return services;
    }

    private static void RegisterClassMaps()
    {
        BsonClassMap.RegisterClassMap<Order>(cm =>
        {
            cm.AutoMap();
            cm.SetIsRootClass(true);
        });
        
        BsonClassMap.RegisterClassMap<InStoreOrder>(cm =>
        {
            cm.AutoMap();
            cm.SetIsRootClass(true);
        });
        
        BsonClassMap.RegisterClassMap<UberEatsOrder>(cm =>
        {
            cm.AutoMap();
            cm.SetIsRootClass(true);
        });
        
        BsonClassMap.RegisterClassMap<MrDOrder>(cm =>
        {
            cm.AutoMap();
            cm.SetIsRootClass(true);
        });
    }
}