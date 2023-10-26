﻿using System.Text.Json;
using AH.Company.Application.Commands.MasterTagCategories;
using AH.Company.Application.Dtos;
using AH.Metadata.Shared.V1.Events;
using AH.Shared.Application.Dtos;
using AH.Shared.Domain.Constants;
using AutoMapper;
using Dapr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.MessageListeners.MasterTagCategories
{
    /// <summary>
    /// Listener for MasterTagCategoryCreate event
    /// </summary>
    public class CreateMasterTagCategoryMessageListener : BaseMessageListener
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        public CreateMasterTagCategoryMessageListener(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
        {
        }

        /// <summary>
        /// Listener for MasterTagCategoryCreate event
        /// </summary>
        /// <param name="message"></param>
        [Topic(PubSubNames.RabbitMq, "MasterTagCategoryCreate")]
        [Route("CreateMasterTagCategoryListener")]
        public async Task CreateMasterTagCategoryListener(EventDto message)
        {
            var model = JsonSerializer.Deserialize<MasterTagCategoryEventDto>(message.Data);
        
            if (model is null)
            {
                Logger.LogError("Received message is null");
                return;
            }
            var dto = Mapper.Map<MasterTagCategoryDto>(model.MasterTagCategory);
            if (dto is null)
            {
                Logger.LogError("Received message is null");
                return;
            }
            Logger.LogInformation("Received message: {@Model}", model);
            var command = new CreateMasterTagCategoryCommand(User, Logger, dto, model.Domain);
            await Mediator.Send(command);
        }
        
        /// <summary>
        /// Listener for MasterTagCategoryUpdate event
        /// </summary>
        /// <param name="message"></param>
        [Topic(PubSubNames.RabbitMq, "MasterTagCategoryUpdate")]
        [Route("UpdateMasterTagCategoryListener")]
        public async Task UpdateMasterTagCategoryListener(EventDto message)
        {
            var model = JsonSerializer.Deserialize<MasterTagCategoryEventDto>(message.Data);
        
            if (model is null)
            {
                Logger.LogError("Received message is null");
                return;
            }
            var dto = Mapper.Map<MasterTagCategoryDto>(model.MasterTagCategory);
            if (dto is null)
            {
                Logger.LogError("Received message is null");
                return;
            }
            Logger.LogInformation("Received message: {@Model}", model);
            
        }
    }
}

