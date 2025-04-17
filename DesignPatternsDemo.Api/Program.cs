using System.Text.Json;
using DesignPatternsDemo.Api.Endpoints.Orders;
using DesignPatternsDemo.Api.Endpoints.Orders.Models;
using DesignPatternsDemo.Api.Endpoints.Orders.Models.InStoreModel;
using DesignPatternsDemo.Api.Endpoints.Orders.Models.MrD;
using DesignPatternsDemo.Api.Endpoints.Orders.Models.UberEats;
using DesignPatternsDemo.Infrastructure;
using FastEndpoints;
using FastEndpoints.Swagger;
using JsonSubTypes;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument()
    .RegisterInfrastructure(builder.Configuration)
    .RegisterOrders();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseFastEndpoints(options =>
    {
        options.Serializer.RequestDeserializer = async (req, tDto, jCtx, ct) =>
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(JsonSubtypesConverterBuilder
                .Of<CreateOrderRequest>("type")
                .SerializeDiscriminatorProperty()
                .RegisterSubtype<InStoreOrderRequest>("Instore")
                .RegisterSubtype<UberEatsOrderRequest>("UberEats")
                .RegisterSubtype<MrDOrderRequest>("MrD")
                .Build());
            
            using var reader = new StreamReader(req.Body);
            return JsonConvert.DeserializeObject(await reader.ReadToEndAsync(), tDto, settings);
        };
        
        options.Serializer.ResponseSerializer = async (rsp, dto, cType, jCtx, ct)=>
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(JsonSubtypesConverterBuilder
                .Of<OrderModel>("type")
                .SerializeDiscriminatorProperty()
                .RegisterSubtype<InStoreModel>("Instore")
                .RegisterSubtype<UberEatsModel>("UberEats")
                .RegisterSubtype<MrDModel>("MrD")
                .Build());
            
            rsp.ContentType = cType;
            var deserializedResult = JsonConvert.SerializeObject(dto, settings);
            await rsp.WriteAsync(deserializedResult, ct);
        };
        
    })
    .UseSwaggerGen();

app.Run();