using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Shared.Application.Commands;
using AH.Shared.Application.Extensions;
using AH.Shared.Application.Interfaces;
using AH.Shared.Domain.Constants;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.MasterTagCategories;
[ExcludeFromCodeCoverage]
public class SendMasterTagCategoryEventCommand : BaseCommand<Unit>
{
    public string EventType { get; }
    public MasterTagCategoryDto MasterTagCategory { get; }

    public SendMasterTagCategoryEventCommand(ClaimsPrincipal user, ILogger logger, string eventType, MasterTagCategoryDto masterTagCategory) : base(user, logger)
    {
        EventType = eventType;
        MasterTagCategory = masterTagCategory;
    }
}
[ExcludeFromCodeCoverage]
public class SendMasterTagCategoryEventCommandHandler :BaseCommandHandler, IRequestHandler<SendMasterTagCategoryEventCommand,Unit>
{
    private readonly IMessageSender _sender;
    
    public SendMasterTagCategoryEventCommandHandler(IMetadataDbContext context, IMapper mapper, IMessageSender sender) : base(context, mapper)
    {
        _sender = sender;
    }
    public async Task<Unit> Handle(SendMasterTagCategoryEventCommand request, CancellationToken cancellationToken)
    {
        var domains = await Context.Domains.ToListAsync(cancellationToken);

        foreach (var domain in domains)
        {
            await _sender.SendEventAsync(PubSubNames.Redis, "MasterTagCategory", request.User.GetUserId(), new MasterTagCategoryEventDto{ Domain = domain.Name, EventType = request.EventType, MasterTagCategory = request.MasterTagCategory });
        }
        
        return Unit.Value;
    }
}