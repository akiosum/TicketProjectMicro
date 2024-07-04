using System.Net;
using FastResults.Errors;
using FastResults.Results;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using TicketProject.Shared.Errors;

namespace TicketProject.Presentation.Handlers;

public class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Exception: {Message}", exception.Message);

        switch (exception)
        {
            case UnauthorizedAccessException:
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await httpContext.Response.WriteAsJsonAsync(new BaseResponse<Error>(TicketError.Common.AccessDenied),
                    cancellationToken);
                break;
            case ValidationException:
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await httpContext.Response.WriteAsJsonAsync(
                    new BaseResponse<Error>(TicketError.Common.Validation(exception.Message)), cancellationToken);
                break;
            default:
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(new BaseResponse<Error>(TicketError.Common.ErrorInternal), cancellationToken);
                break;
        }

        return true;
    }
}