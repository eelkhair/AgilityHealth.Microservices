using System.Security.Claims;
using AH.User.Application.Dtos;
using AH.User.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.User.Application.Commands.Auth;

public class StoreAuth0TokenCommand(ClaimsPrincipal user, ILogger logger) : BaseCommand<string>(user, logger);

public class StoreAuth0TokenCommandHandler(IUsersDbContext context, IMapper mapper, IAuthFactory authFactory, IDaprUtility daprUtility)
    : BaseCommandHandler(context, mapper), IRequestHandler<StoreAuth0TokenCommand, string>
{

    private readonly IAuthResource _authResource = authFactory.CreateAuthResource();
    public async Task<string> Handle(StoreAuth0TokenCommand request, CancellationToken cancellationToken)
    {
        
        var token = await _authResource.GetTokenAsync();
        
        var obj = new TokenDto(token, DateTime.UtcNow);
        
        await daprUtility.SaveStateAsync("statestore.redis", "auth0token", obj, cancellationToken);
        return token;
    }
}