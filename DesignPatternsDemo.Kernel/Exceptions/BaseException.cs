using Microsoft.AspNetCore.Http;

namespace DesignPatternsDemo.Kernel.Exceptions;

public class BaseException : Exception
{
    public string? FriendlyMessage { get; }
    public int StatusCode { get; }

    protected BaseException(string message,
        string? friendlyMessage,
        int? status,
        Exception? exception = null) : base(message, exception)
    {
        FriendlyMessage = friendlyMessage;
        StatusCode = status ?? StatusCodes.Status400BadRequest;
    }
}