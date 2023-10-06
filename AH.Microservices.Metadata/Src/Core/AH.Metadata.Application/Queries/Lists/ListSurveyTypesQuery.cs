using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Shared.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.Lists;

public class ListSurveyTypesQuery :BaseQuery<List<SurveyTypeDto>>
{
    public ListSurveyTypesQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
}

public class ListSurveyTypesQueryHandler : BaseQueryHandler, IRequestHandler<ListSurveyTypesQuery, List<SurveyTypeDto>>
{
    public ListSurveyTypesQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<SurveyTypeDto>> Handle(ListSurveyTypesQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting survey types");
        var surveyTypes = await Context.SurveyTypes.ToListAsync(cancellationToken);
        return Mapper.Map<List<SurveyTypeDto>>(surveyTypes);
    }
}