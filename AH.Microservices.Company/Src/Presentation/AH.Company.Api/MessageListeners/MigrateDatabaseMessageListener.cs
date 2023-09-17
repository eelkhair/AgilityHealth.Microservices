using AH.Shared.Application.Dtos;
using AH.Shared.Domain.Constants;
using AutoMapper;
using Dapr;
using MediatR;

namespace AH.Company.Api.MessageListeners;

public class MigrateDatabaseMessageListener : BaseMessageListener
{
    public MigrateDatabaseMessageListener(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    [Topic(PubSubNames.Redis, "DomainAdded")]
    public  Task MigrateDatabaseAsync(EventDto dto)
    {
         return Task.CompletedTask;
    }
    
}