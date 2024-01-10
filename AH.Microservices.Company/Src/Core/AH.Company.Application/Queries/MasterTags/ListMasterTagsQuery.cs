using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Queries.MasterTags;

public class ListMasterTagsQuery(ClaimsPrincipal user, ILogger logger)
    : BaseQuery<List<MasterTagDto>>(user, logger);

public class ListMasterTagsQueryHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseQueryHandler(context, mapper),
        IRequestHandler<ListMasterTagsQuery, List<MasterTagDto>>
{
    public async Task<List<MasterTagDto>> Handle(ListMasterTagsQuery request,
        CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Getting master tags");
        var masterTags = await Context.MasterTags.Select(x=> new MasterTag
        {
            Name = x.Name,
            ClassName = x.ClassName,
            UId = x.UId,
            MasterTagCategory = new MasterTagCategory
            {
                Name = x.MasterTagCategory.Name,
                UId = x.MasterTagCategory.UId,
                ClassName = x.MasterTagCategory.ClassName,
                Type = x.MasterTagCategory.Type
            }
        }).ToListAsync(cancellationToken);
        return Mapper.Map<List<MasterTagDto>>(masterTags);
    }
}