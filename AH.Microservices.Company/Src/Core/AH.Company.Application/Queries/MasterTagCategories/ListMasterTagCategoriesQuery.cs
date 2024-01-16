using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
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
       // var masterTagCategories = await Context.MasterTagCategories.Include(x=>x.MasterTags).ToListAsync(cancellationToken);
        
       var masterTagCategories = await Context.MasterTagCategories.Select(x=> new MasterTagCategory
        {
            Name = x.Name,
            ClassName = x.ClassName,
            UId = x.UId,
            Type = x.Type,
            MasterTags = x.MasterTags.Select(x=> new MasterTag
            {
                Name = x.Name,
                ClassName = x.ClassName,
                UId = x.UId
            }).ToList()
        }).ToListAsync(cancellationToken);
       
       return Mapper.Map<List<MasterTagCategoryDto>>(masterTagCategories);
    }
}