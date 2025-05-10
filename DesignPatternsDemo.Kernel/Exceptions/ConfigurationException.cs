using Microsoft.AspNetCore.Http;

namespace DesignPatternsDemo.Kernel.Exceptions;

public class ConfigurationException(
    string message,
    Exception? exception = null,
    string? friendlyMessage = null)
    : BaseException(message, friendlyMessage, StatusCodes.Status500InternalServerError, exception);