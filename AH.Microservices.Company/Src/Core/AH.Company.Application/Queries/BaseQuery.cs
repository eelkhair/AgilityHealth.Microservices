using System.Security.Claims;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries;

public abstract class BaseQuery<TResponse> : IRequest<TResponse>
{
    protected BaseQuery(ClaimsPrincipal user, ILogger logger)
    {
        User = user;
        Logger = logger;
    }

    public ClaimsPrincipal User { get; set; }

    [JsonIgnore]
    public ILogger Logger { get; }
}