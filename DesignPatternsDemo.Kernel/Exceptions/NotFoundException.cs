using Microsoft.AspNetCore.Http;

namespace DesignPatternsDemo.Kernel.Exceptions;

public class NotFoundException : BaseException
{
    public string? EntityName { get; }
    public object? Id { get; }

    public NotFoundException(string entityName, 
        object id, 
        string? friendlyMessage = null) : base($"{entityName} with identifier '{id}' was not found", friendlyMessage, 404)
    {
        EntityName = entityName;
        Id = id;
    }

    public NotFoundException(string message, 
        string? friendlyMessage = null) : base(message, friendlyMessage, StatusCodes.Status404NotFound)
    {
        
    }
}