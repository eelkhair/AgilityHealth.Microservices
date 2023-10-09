using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Shared.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.MasterTagCategories;

public class ListMasterTagCategoriesWithTagsQuery : BaseQuery<List<MasterTagCategoryDto>>
{
    public ListMasterTagCategoriesWithTagsQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
}

public class ListMasterTagCategoriesWithTagsQueryHandler : BaseQueryHandler, IRequestHandler<ListMasterTagCategoriesWithTagsQuery, List<MasterTagCategoryDto>>
{
    public ListMasterTagCategoriesWithTagsQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<MasterTagCategoryDto>> Handle(ListMasterTagCategoriesWithTagsQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting all master tag categories");
        var masterTagCategories = await Context.MasterTagCategories.Include(x=> x.MasterTags).ToListAsync(cancellationToken);
        return Mapper.Map<List<MasterTagCategoryDto>>(masterTagCategories);
    }
}