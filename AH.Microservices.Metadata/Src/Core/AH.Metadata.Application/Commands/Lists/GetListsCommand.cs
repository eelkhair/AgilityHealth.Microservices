using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Extensions;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Lists;

public class GetListsCommand : BaseCommand<ListDto>{
    public GetListsCommand(ClaimsPrincipal user, ILogger logger, List<string> listTypes) : base(user, logger)
    {
        ListTypes = listTypes;
        logger.LogInformation("{User}", user.GetUserId());
    }
	
    public List<string> ListTypes { get; }
}

public class GetListsCommandHandler(IMetadataDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<GetListsCommand, ListDto>
{
    public async Task<ListDto> Handle(GetListsCommand request, CancellationToken cancellationToken)
    {
        var result = new Dictionary<string, object>();
        foreach (var listType in request.ListTypes.Distinct(StringComparer.InvariantCultureIgnoreCase))
        {
            switch (listType)
            {
                case ListTypes.Countries:
                    request.Logger.LogInformation("Getting countries");
                    var countries = await Context.Countries.ToListAsync(cancellationToken);
                    result.Add(listType, Mapper.Map<List<CountryDto>>(countries) );
                    break;
                
                case ListTypes.SurveyTypes:
                    request.Logger.LogInformation("Getting survey types");
                    var surveyTypes = await Context.SurveyTypes.ToListAsync(cancellationToken);
                    result.Add(listType, Mapper.Map<List<SurveyTypeDto>>(surveyTypes));
                    break;
                
                case ListTypes.Industries:
                    request.Logger.LogInformation("Getting industries");
                    var industries = await Context.Industries.ToListAsync(cancellationToken);
                    result.Add(listType, Mapper.Map<List<IndustryDto>>(industries));
                    break;
                
                case ListTypes.GrowthPlanStatuses:
                    request.Logger.LogInformation("Getting growth plan statuses");
                    var growthPlanStatuses = await Context.GrowthPlanStatuses.ToListAsync(cancellationToken);
                    result.Add(listType, Mapper.Map<List<GrowthPlanStatusDto>>(growthPlanStatuses));
                    break;
            }
        }

        return new ListDto { Data = result};
    }
}

public class GetListsCommandValidator : AbstractValidator<GetListsCommand>
{
    public GetListsCommandValidator()
    {
        RuleFor(x => x)
            .Custom((command, context) =>
            {
                if (!command.ListTypes.Any())
                {
                    context.AddFailure(new ValidationFailure
                    {
                        ErrorCode = "900", ErrorMessage = ValidationMessages.ListTypeNotEmpty,
                        PropertyName = "ListTypes"
                    });
                }

                var invalidItems = command.ListTypes.Where(item =>
                        item != ListTypes.Countries &&
                        item != ListTypes.SurveyTypes &&
                        item != ListTypes.Industries &&
                        item != ListTypes.GrowthPlanStatuses)
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