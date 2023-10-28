using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Shared.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.MasterTagCategories;

public class ListMasterTagCategoriesQuery: BaseQuery<List<MasterTagCategoryDto>>
{
    public ListMasterTagCategoriesQuery(ClaimsPrincipal user, ILogger logger) : base(user, logger)
    {
    }
}

public class ListMasterTagCategoriesQueryHandler : BaseQueryHandler,
    IRequestHandler<ListMasterTagCategoriesQuery, List<MasterTagCategoryDto>>
{
    public ListMasterTagCategoriesQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper, IHttpContextAccessor accessor) : base(context, mapper, accessor)
    {
        
    }

    public async Task<List<MasterTagCategoryDto>> Handle(ListMasterTagCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting master tag categories");
        var masterTagCategories = await Context.MasterTagCategories.ToListAsync(cancellationToken);
        return Mapper.Map<List<MasterTagCategoryDto>>(masterTagCategories);
    }
}