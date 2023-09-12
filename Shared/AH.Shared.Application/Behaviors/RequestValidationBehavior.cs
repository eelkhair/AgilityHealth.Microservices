using System.Text.Json.Serialization;
using AH.Shared.Application.Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using ValidationException =  AH.Shared.Application.Exceptions.ValidationException;
namespace AH.Shared.Application.Behaviors;



public  class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest :  IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    [JsonIgnore]
    private readonly ILogger<BaseCommand<TResponse>> _logger;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<BaseCommand<TResponse>> logger)
    {
        _validators = validators;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        _logger.LogInformation("Validating request: {Request}", request);
        
        var failures = _validators
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
      