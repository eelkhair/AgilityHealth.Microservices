using System.Text.Json.Serialization;
using AH.Company.Application.Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ValidationException =  AH.Company.Application.Exceptions.ValidationException;

namespace AH.Company.Application.Behaviors;

public class RequestValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators,
    ILogger<BaseCommand<TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    [JsonIgnore]
    private readonly ILogger<BaseCommand<TResponse>> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        _logger.LogInformation("Validating request: {Request}", request);
        
        var failures = validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if(failures.Count != 0)
        {
            _logger.LogError("Validation errors - {FailuresCount} failures", failures.Count);
            throw new ValidationException(failures);
        }
        _logger.LogInformation("Request validated: {Request}", request);

        return await  next();
    }
}
      