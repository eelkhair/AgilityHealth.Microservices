using System.Security.Claims;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.User.Application.Queries;

public abstract class BaseQuery<TResponse>(ClaimsPrincipal user, ILogger logger) : IRequest<TResponse>
{
    public ClaimsPrincipal User { get; set; } = user;

    [JsonIgnore]
    public ILogger Logger { get; } = logger;
}