using DesignPatternsDemo.Api.Endpoints.Orders.Models;
using DesignPatternsDemo.Api.Endpoints.Orders.Models.InStoreModel;
using DesignPatternsDemo.Api.Endpoints.Orders.Models.UberEats;
using DesignPatternsDemo.Domain.Orders;
using DesignPatternsDemo.Kernel;

namespace DesignPatternsDemo.Api.Endpoints.Orders;

public static class OrdersModule
{
    public static IServiceCollection RegisterOrders(this IServiceCollection services)
    {
        //Register Mappers 
        services.AddSingleton<ICustomMapper<OrderItemModel, OrderItem>, OrderItemMapper>();
        services.AddSingleton<ICustomMapper<OrderItem, OrderItemModel>, OrderItemModelMapper>();
        
        services.AddSingleton<IOrderFactoryResolver, OrderFactoryResolver>();
        
        //Register Factories
        services.AddSingleton<IOrderFactory, UberEatsOrderFactory>();
        services.AddSingleton<IOrderFactory, InStoreOrderFactory>();
        
        return services;
    }
}