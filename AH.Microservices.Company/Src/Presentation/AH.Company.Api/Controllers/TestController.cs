using AH.Company.Application.Interfaces;
using AH.Shared.Application.Interfaces;
using AH.Shared.Domain.Constants;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Company.Api.Controllers;

public class TestController : BaseController
{
    private readonly ICompanyMicroServiceDbContext _context;

    public TestController(IMapper mapper, ILogger<TestController> logger , IMediator mediator, ICompanyMicroServiceDbContext context) : base(mapper, logger, mediator)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {

        _context.SetConnectionString(Request.Headers.Host.ToString());
        return Ok(_context.GetConnectionString());
    }
}