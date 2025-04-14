using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace DesignPatternsDemo.Kernel.Mongo;

public static class MongoKernelModule
{
    private const string MongoDbConnectionStringName = "MongoDB";
    
    public static IServiceCollection RegisterMongoKernel(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        //Allows for the serialization of all types including types that implement an interface
        var objectSerializer = new ObjectSerializer(ObjectSerializer.AllAllowedTypes);
        BsonSerializer.RegisterSerializer(objectSerializer);
        
        RegisterConventions();
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

        string connectionString = configuration.GetConnectionString(MongoDbConnectionStringName) ?? throw new Exceptions.ConfigurationException($"{MongoDbConnectionStringName} connection string is missing or not configured properly.");
        services.TryAddSingleton<IMongoClient>(_ => new MongoClient(connectionString));
        
        return services;;
    }
    
    private static void RegisterConventions()
    {
        bool ApplyToAllTypes(Type _) => true;

        ConventionRegistry.Register(
            "CamelCase Properties Convention",
            new ConventionPack { new CamelCaseElementNameConvention() },
            ApplyToAllTypes
        );
    }
}

