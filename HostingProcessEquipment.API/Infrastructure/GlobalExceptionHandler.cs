using HostingProcessEquipment.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using FluentValidation;

namespace HostingProcessEquipment.API.Infrastructure;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
            CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            ValidationException validationException => CreateValidationProblemDetails(validationException),
            ApiException apiException => new ProblemDetails
            {
                Title = "API exception",
                Status = apiException.HttpStatusCode
            },
            _ => new ProblemDetails
            {
                Title = "Server error",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message
            }
        };

        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = MediaTypeNames.Application.ProblemJson;

        await httpContext.Response.WriteAsJsonAsync(problemDetails,
                problemDetails.GetType(),
                cancellationToken: cancellationToken);
        return true;
    }

    private static ValidationProblemDetails CreateValidationProblemDetails(ValidationException validationException)
    {
        var validationProblemDetails = new ValidationProblemDetails
        {
            Title = "One or more validation problems occurred",
            Status = StatusCodes.Status400BadRequest,
            Detail = "See the errors property for details"
        };

        foreach (var error in validationException.Errors)
        {
            validationProblemDetails.Errors.Add(error.PropertyName, new[] { error.ErrorMessage, error.ErrorCode });
        }

        return validationProblemDetails;
    }
}
