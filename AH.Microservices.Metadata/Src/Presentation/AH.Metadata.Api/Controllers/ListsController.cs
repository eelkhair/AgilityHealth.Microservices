using AH.Metadata.Application.Commands.Lists;
using AH.Metadata.Application.Queries.Lists;
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
    public ListsController(IMapper mapper, ILogger<ListsController> logger, IMediator mediator) : base(mapper, logger, mediator)
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
        var query = new ListCountriesQuery(User, Logger);
        var countries = await Mediator.Send(query);
        var vm = Mapper.Map<List<CountryResponse>>(countries);
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
        var query = new ListSurveyTypesQuery(User, Logger);
        var surveyTypes = await Mediator.Send(query);
        var vm = Mapper.Map<List<SurveyTypeResponse>>(surveyTypes);
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
        var query = new ListIndustriesQuery(User, Logger);
        var industries = await Mediator.Send(query);
        var vm = Mapper.Map<List<IndustryResponse>>(industries);
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
        var query = new ListGrowthPlanStatusesQuery(User, Logger);
        var growthPlanStatuses = await Mediator.Send(query);
        var vm = Mapper.Map<List<GrowthPlanStatusResponse>>(growthPlanStatuses);
        return Ok(vm);
    }
}