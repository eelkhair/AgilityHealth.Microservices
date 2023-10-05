using AH.Shared.Application.Interfaces;
using AH.Shared.Domain.Constants;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

public class TestController : BaseController
{
    private readonly IConfiguration _configuration;
    private readonly IMessageSender _sender;


    public TestController(IMapper mapper, ILogger<TestController> logger , IMediator mediator, IConfiguration configuration, IMessageSender sender) : base(mapper, logger, mediator)
    {
        _configuration = configuration;
        _sender = sender;

    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {

        await _sender.SendEventAsync(PubSubNames.Redis, TopicNames.Metadata, "test", new { test = "test" });
        return Ok();
    }
}