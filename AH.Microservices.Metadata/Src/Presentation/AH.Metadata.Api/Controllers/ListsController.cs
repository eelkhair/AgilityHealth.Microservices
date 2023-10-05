﻿using AH.Metadata.Application.Commands.Lists;
using AH.Metadata.Shared.V1.Constants;
using AH.Metadata.Shared.V1.Models.Responses;
using AH.Metadata.Shared.V1.Models.Responses.Lists;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AH.Metadata.Api.Controllers;

/// <summary>
/// Represents a ListsController.

/// </summary>

public class ListsController : BaseController
{
    /// <summary>
    /// Constructor for ListsController. 
    /// </summary>
    /// <param name="mapper">The mapper.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="mediator">The mediator.</param>
    public ListsController(IMapper mapper, ILogger logger, IMediator mediator) : base(mapper, logger, mediator)
    {
    }

    /// <summary>
    /// Get a list of options for all dropdowns and multi-selects
    /// </summary>
    /// <param name="types">Select from "survey-types", "countries", "growth-plan-statuses", "industries".</param>
    /// <response code="200">Successfully retrieved list of options</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(ListResponse), StatusCodes.Status200OK)]

    [HttpPost]
    public async Task<IActionResult> GetSelectionLists(List<string> types)
    {
        var command = new GetListsCommand(User, Logger, types);
        var selectionLists = await Mediator.Send(command);
        var vm = Mapper.MapLists(selectionLists);
        return Ok(vm);
    }

    /// <summary>
    /// Get a list of countries
    /// </summary>
    /// <response code="200">Successfully retrieved list of countries</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<CountryResponse>), StatusCodes.Status200OK)]
    [HttpGet("countries")]
    public async Task<IActionResult> GetCountries()
    {
        var command = new GetListsCommand(User, Logger, new List<string> { ListTypes.Countries });
        var countries = await Mediator.Send(command);
        var vm = Mapper.Map<List<CountryResponse>>(countries.Data[ListTypes.Countries]);
        return Ok(vm);
    }

    /// <summary>
    /// Get a list of survey types
    /// </summary>
    /// <response code="200">Successfully retrieved list of survey types</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<SurveyTypeResponse>), StatusCodes.Status200OK)]
    [HttpGet("survey-types")]
    public async Task<IActionResult> GetSurveyTypes()
    {
        var command = new GetListsCommand(User, Logger, new List<string> { ListTypes.SurveyTypes });
        var surveyTypes = await Mediator.Send(command);
        var vm = Mapper.Map<List<SurveyTypeResponse>>(surveyTypes.Data[ListTypes.SurveyTypes]);
        return Ok(vm);
    }

    /// <summary>
    /// Get a list of industries
    /// </summary>
    /// <response code="200">Successfully retrieved list of industries</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<IndustryResponse>), StatusCodes.Status200OK)]
    [HttpGet("industries")]
    public async Task<IActionResult> GetIndustries()
    {
        var command = new GetListsCommand(User, Logger, new List<string> { ListTypes.Industries });
        var industries = await Mediator.Send(command);
        var vm = Mapper.Map<List<IndustryResponse>>(industries.Data[ListTypes.Industries]);
        return Ok(vm);
    }

    /// <summary>
    /// Get a list of growth plan statuses
    /// </summary>
    /// <response code="200">Successfully retrieved list of growth plan statuses</response>
    /// <response code="500">Internal Server Error</response>
    /// <returns></returns>
    [ProducesResponseType(typeof(List<GrowthPlanStatusResponse>), StatusCodes.Status200OK)]
    [HttpGet("growth-plan-statuses")]
    public async Task<IActionResult> GetGrowthPlanStatuses()
    {
        var command = new GetListsCommand(User, Logger, new List<string> { ListTypes.GrowthPlanStatuses });
        var growthPlanStatuses = await Mediator.Send(command);
        var vm = Mapper.Map<List<GrowthPlanStatusResponse>>(growthPlanStatuses.Data[ListTypes.GrowthPlanStatuses]);
        return Ok(vm);
    }
}