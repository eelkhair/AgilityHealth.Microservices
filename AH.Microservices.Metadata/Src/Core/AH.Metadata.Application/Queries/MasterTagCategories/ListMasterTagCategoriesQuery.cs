using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Shared.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.MasterTagCategories;

public class ListMasterTagCategoriesQuery: BaseQuery<List<MasterTagCategoryDto>>
{
    public ListMasterTagCategoriesQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
}

public class ListMasterTagCategoriesQueryHandler : BaseQueryHandler,
    IRequestHandler<ListMasterTagCategoriesQuery, List<MasterTagCategoryDto>>
{
    public ListMasterTagCategoriesQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<MasterTagCategoryDto>> Handle(ListMasterTagCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting master tag categories");
        var masterTagCategories = await Context.MasterTagCategories.ToListAsync(cancellationToken);
        return Mapper.Map<List<MasterTagCategoryDto>>(masterTagCategories);
    }
}