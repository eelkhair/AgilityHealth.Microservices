using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.MasterTagCategories;

public class ListMasterTagCategoriesQuery(ClaimsPrincipal user, ILogger logger)
    : BaseQuery<List<MasterTagCategoryDto>>(user, logger);

public class ListMasterTagCategoriesQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListMasterTagCategoriesQuery, List<MasterTagCategoryDto>>
{
    public async Task<List<MasterTagCategoryDto>> Handle(ListMasterTagCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting master tag categories");
        var masterTagCategories = await Context.MasterTagCategories.ToListAsync(cancellationToken);
        return Mapper.Map<List<MasterTagCategoryDto>>(masterTagCategories);
    }
}