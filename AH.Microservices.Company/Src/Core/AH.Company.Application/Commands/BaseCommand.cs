using System.Security.Claims;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands;

public abstract class BaseCommand<TResponse>(ClaimsPrincipal user, ILogger logger) : IRequest<TResponse>
{
    [JsonIgnore]
    public ClaimsPrincipal User { get; } = user;

    [JsonIgnore]
    public ILogger Logger { get; } = logger;
}