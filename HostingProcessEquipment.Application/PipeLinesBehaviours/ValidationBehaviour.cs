using FluentValidation;
using MediatR;

namespace HostingProcessEquipment.Application.PipeLinesBehaviours;
internal sealed class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
{

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (!validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults =
            await Task.WhenAll(validators.Select(i => i.ValidateAsync(context, cancellationToken)));

        var failures = validationResults.SelectMany(i => i.Errors).Where(f => f != null).ToList();

        return failures.Any() ? throw new ValidationException(failures) : await next();
    }
}


