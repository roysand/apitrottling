using System.Net;
using System.Text.Json;
using ApiTrottling.Application.Common.Exceptions;
using ApiTrottling.Domain.Exceptions;

namespace Api.Middleware;

public class CustomExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        
        var result = exception.Message;

        switch (exception)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException.Errors);
                break;

            case BadRequestException badRequestException:
                code = HttpStatusCode.BadRequest;
                result = badRequestException.Message;
                break;

            case NotFoundException notFoundException:
                code = HttpStatusCode.NotFound;
                result = notFoundException.Message;
                break;

            case BusinessRuleException businessRuleException:
                code = HttpStatusCode.Conflict;
                result = businessRuleException.Message;
                break;
            
            case ConfigException configException:
                code = HttpStatusCode.InternalServerError;
                result = configException.Message;
                break;
            
            case MobilePhoneInvalidException mobilePhoneInvalidException:
                code = HttpStatusCode.BadRequest;
                result = mobilePhoneInvalidException.Message;
                break;
            
            case InternalServerException internalServerException:
                code = HttpStatusCode.InternalServerError;
                result = internalServerException.Message;
                break;
            
            case InitializationBusyException initializationBusyException:
                code = (HttpStatusCode)589;
                result = initializationBusyException.Message;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (result == string.Empty)
        {
            result = JsonSerializer.Serialize(new { error = exception.Message });
        }

        if ((int)code < 500)
            _logger.LogWarning($"Error code: {(int)code}, message: {result}");
        else
            _logger.LogError($"Error code: {(int)code}, message: {result}");

        return context.Response.WriteAsync(result);
    }
}

public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
