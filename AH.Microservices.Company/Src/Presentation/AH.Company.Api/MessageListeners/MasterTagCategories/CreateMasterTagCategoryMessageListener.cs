using System.Text.Json;
using AH.Metadata.Shared.V1.Events;
using AH.Shared.Application.Dtos;
using AH.Shared.Domain.Constants;
using AutoMapper;
using Dapr;
using MediatR;

namespace AH.Company.Api.MessageListeners.MasterTagCategories;

/// <inheritdoc />
public class CreateMasterTagCategoryMessageListener : BaseMessageListener
{
    /// <inheritdoc />
    public CreateMasterTagCategoryMessageListener(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }
    
    [Topic(PubSubNames.RabbitMq, "MasterTagCategoryCreate")]
    public async Task CreateMasterTagCategoryListener(EventDto message)
    {
       var dto = JsonSerializer.Deserialize<MasterTagCategoryEventDto>(message.Data);
        Logger.LogInformation("Received message: {Dto}", message.Data);
    }
    
}