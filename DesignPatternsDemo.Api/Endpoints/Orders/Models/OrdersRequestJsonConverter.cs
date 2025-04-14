using System.Text.Json;
using System.Text.Json.Serialization;
using DesignPatternsDemo.Api.Endpoints.Orders.Models.InStoreModel;
using DesignPatternsDemo.Api.Endpoints.Orders.Models.UberEats;
using FastEndpoints;

namespace DesignPatternsDemo.Api.Endpoints.Orders.Models;

public class OrderRequestConverterOptions
{
    private readonly Dictionary<string, Type> _typeMap = new();

    public OrderRequestConverterOptions RegisterSubType<T>(string typeName) where T : CreateOrderRequest
    {
        _typeMap[typeName] = typeof(T);
        return this;
    }

    internal Type ResolveType(string typeName)
    {
        return _typeMap.TryGetValue(typeName, out Type? type) 
            ? type 
            : throw new JsonException($"Unknown order request type: {typeName}");
    }
}

public class OrderRequestJsonConverter : JsonConverter<CreateOrderRequest>
{
    private readonly OrderRequestConverterOptions externalOption = new();

    public OrderRequestJsonConverter()
    {
    }

    public OrderRequestJsonConverter(Action<OrderRequestConverterOptions> configure)
    {
        configure(externalOption);
    }

    public override bool CanConvert(Type typeToConvert) =>
        typeof(CreateOrderRequest).IsAssignableFrom(typeToConvert);

    public override CreateOrderRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        
        if (!root.TryGetProperty("type", out var typeProperty))
            throw new JsonException("The 'type' property is required for order request deserialization");
        
        var requestType = typeProperty.GetString() 
                          ?? throw new JsonException("The 'type' property cannot be null");
        
        var targetType = this.externalOption.ResolveType(requestType);
        return (CreateOrderRequest)JsonSerializer.Deserialize(root.GetRawText(), targetType, options)!;
    }

    public override void Write(Utf8JsonWriter writer, CreateOrderRequest value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}

// Create a custom binder for your abstract class
public class CreateOrderRequestBinder : IRequestBinder<CreateOrderRequest>
{
    public bool CanBind(Type dtoType) => typeof(CreateOrderRequest).IsAssignableFrom(dtoType);

    public async ValueTask<CreateOrderRequest> BindAsync(BinderContext ctx, CancellationToken ct)
    {
        // Create your converter
        var orderConverter = new OrderRequestJsonConverter(opts => 
            opts.RegisterSubType<InStoreOrderRequest>("Instore")
                .RegisterSubType<UberEatsOrderRequest>("UberEats")
        );

        // Configure JSON options
        var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            PropertyNameCaseInsensitive = true
        };
        jsonOptions.Converters.Add(orderConverter);

        // Read request body
        using var reader = new StreamReader(ctx.HttpContext.Request.Body);
        var json = await reader.ReadToEndAsync(ct);

        // Deserialize with our custom options
        var result = JsonSerializer.Deserialize<CreateOrderRequest>(json, jsonOptions);
        
        if (result == null)
            throw new InvalidOperationException("Failed to deserialize request body");
            
        return result;
    }
}