using System.Text.Json;
using AH.Company.Application.Dtos;
using AH.Shared.Application.Dtos;
using AH.Shared.Domain.Constants;
using AutoMapper;
using Dapr;
using MediatR;

namespace AH.Company.Api.MessageListeners;

/// <inheritdoc />
public class MasterTagCategoryMessageListener : BaseMessageListener
{
    /// <inheritdoc />
    public MasterTagCategoryMessageListener(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    [Topic(PubSubNames.Redis, "CreateMasterTagCategory")]
    public async Task CreateMasterTagCategory(EventDto message)
    {
        var dto = JsonSerializer.Deserialize<MasterTagCategoryEventDto>(message.Data);
    }
    
    [Topic(PubSubNames.Redis, "UpdateMasterTagCategory")]
    public async Task UpdateMasterTagCategory(EventDto message)
    {
        var dto = JsonSerializer.Deserialize<MasterTagCategoryEventDto>(message.Data);
    }
}