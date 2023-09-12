using System.Security.Claims;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Shared.Application.Commands;

public abstract class BaseCommand<TResponse> : IRequest<TResponse>
{
    protected BaseCommand(ClaimsPrincipal user, ILogger logger)
    {
        User = user;
        Logger = logger;
    }
    [JsonIgnore]
    public ClaimsPrincipal User { get; }
    [JsonIgnore]
    public ILogger Logger { get; }
}