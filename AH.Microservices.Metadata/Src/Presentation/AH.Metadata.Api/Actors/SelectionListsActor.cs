using System.Security.Claims;
using AH.Metadata.Api.Models;
using AH.Metadata.Application.Commands.SelectionLists;
using AH.Metadata.Shared.V1.ActorInterfaces;
using AH.Metadata.Shared.V1.Models.Responses;
using AutoMapper;
using Dapr.Actors.Runtime;
using MediatR;

namespace AH.Metadata.Api.Actors;

/// <summary>
/// SelectionListsActor
/// </summary>
public class SelectionListsActor : Actor, ISelectionListsActor
{
    private readonly IMapper _mapper;
    private readonly ILogger<SelectionListsActor> _logger;
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor for SelectionListsActor
    /// </summary>
    /// <param name="host"></param>
    /// <param name="logger"></param>
    /// <param name="provider"></param>
    public SelectionListsActor(ActorHost host, ILogger<SelectionListsActor> logger, IServiceProvider provider) : base(host)
    {
        _mapper = provider.GetRequiredService<IMapper>();
        _logger = logger;
        _mediator = provider.GetRequiredService<IMediator>();
    }
    
    /// <summary>
    /// Gets a list of options for different dropdowns and multi-selects
    /// </summary>
    /// <param name="types"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<SelectionListResponse> GetSelectionLists(List<string> types, string userId)
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userId)
        }));
        
        _logger.LogInformation("Getting selection lists");
        var command = new GetSelectionListsCommand(user, Logger, types);
        var selectionLists = await _mediator.Send(command);
        _logger.LogInformation("building response");
        var vm = _mapper.MapSelectionList(selectionLists);
        return vm;
    }
}