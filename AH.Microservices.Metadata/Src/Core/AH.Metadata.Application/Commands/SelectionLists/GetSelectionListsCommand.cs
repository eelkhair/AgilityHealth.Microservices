using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AH.Shared.Application.Commands;
using AH.Shared.Application.Extensions;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.SelectionLists;

public class GetSelectionListsCommand : BaseCommand<SelectionListDto>{
    public GetSelectionListsCommand(ClaimsPrincipal user, ILogger logger, List<string> listTypes) : base(user, logger)
    {
        ListTypes = listTypes;
        logger.LogInformation("{User}", user.GetUserId());
    }
	
    public List<string> ListTypes { get; }
}

public class GetSelectionListsCommandHandler : BaseCommandHandler, IRequestHandler<GetSelectionListsCommand, SelectionListDto>
{
    public GetSelectionListsCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<SelectionListDto> Handle(GetSelectionListsCommand request, CancellationToken cancellationToken)
    {
        var result = new Dictionary<string, object>();
        foreach (var listType in request.ListTypes.Distinct(StringComparer.InvariantCultureIgnoreCase))
        {
            switch (listType)
            {
                case SelectionListTypes.Countries:
                    request.Logger.LogInformation("Getting countries");
                    var countries = await Context.Countries.ToListAsync(cancellationToken);
                    result.Add(listType, Mapper.Map<List<CountryDto>>(countries) );
                    break;
                
                case SelectionListTypes.SurveyTypes:
                    request.Logger.LogInformation("Getting survey types");
                    var surveyTypes = await Context.SurveyTypes.ToListAsync(cancellationToken);
                    result.Add(listType, Mapper.Map<List<SurveyTypeDto>>(surveyTypes));
                    break;
                
                case SelectionListTypes.Industries:
                    request.Logger.LogInformation("Getting industries");
                    var industries = await Context.Industries.ToListAsync(cancellationToken);
                    result.Add(listType, Mapper.Map<List<IndustryDto>>(industries));
                    break;
                
                case SelectionListTypes.GrowthPlanStatuses:
                    request.Logger.LogInformation("Getting growth plan statuses");
                    var growthPlanStatuses = await Context.GrowthPlanStatuses.ToListAsync(cancellationToken);
                    result.Add(listType, Mapper.Map<List<GrowthPlanStatusDto>>(growthPlanStatuses));
                    break;
            }
        }

        return new SelectionListDto(){ Data = result};
    }
}

public class GetSelectionListsCommandValidator : AbstractValidator<GetSelectionListsCommand>
{
    public GetSelectionListsCommandValidator()
    {
        RuleFor(x => x)
            .Custom((command, context) =>
            {
                var invalidItems = command.ListTypes.Where(item =>
                        item != SelectionListTypes.Countries &&
                        item != SelectionListTypes.SurveyTypes &&
                        item != SelectionListTypes.Industries &&
                        item != SelectionListTypes.GrowthPlanStatuses)
                    .ToList();

                if (!invalidItems.Any()) return;

                invalidItems.ForEach(item =>
                    {
                        context.AddFailure(new ValidationFailure
                            { ErrorCode = "900", ErrorMessage = "'" + item + "' doesn't exist", PropertyName = item });
                    }
                );
            });
    }
}