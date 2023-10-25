using System.Text.Json;
using AH.Company.Application.Interfaces;
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
    public CreateMasterTagCategoryMessageListener(IMapper mapper, ILogger logger, IMediator mediator, ICompanyMicroServiceDbContext context) : base(mapper, logger, mediator, context)
    {
    }

    [Topic(PubSubNames.RabbitMq, "MasterTagCategoryCreate")]
    public async Task CreateMasterTagCategoryListener(EventDto message)
    {
       var dto = JsonSerializer.Deserialize<MasterTagCategoryEventDto>(message.Data);
        Logger.LogInformation("Received message: {Dto}", message.Data);

        Context.SetConnectionString(dto.Domain);
        
        Logger.LogInformation(Context.GetConnectionString());
    }
    
    
}