using System.Security.Claims;
using AH.User.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.User.Application.Commands.Auth;

public class StoreAuth0TokenCommand(ClaimsPrincipal user, ILogger logger) : BaseCommand<Unit>(user, logger);

public class StoreAuth0TokenCommandHandler(IUsersDbContext context, IMapper mapper, IAuthFactory authFactory, IDaprUtility daprUtility)
    : BaseCommandHandler(context, mapper), IRequestHandler<StoreAuth0TokenCommand, Unit>
{

    private readonly IAuthResource _authResource = authFactory.CreateAuthResource();
    public async Task<Unit> Handle(StoreAuth0TokenCommand request, CancellationToken cancellationToken)
    {
        
        var token = await _authResource.GetTokenAsync();
        
        var obj = new {token, CreatedAt = DateTime.UtcNow};
        await daprUtility.SaveStateAsync("statestore.redis", "auth0token", obj, cancellationToken);
        return Unit.Value;
    }
}