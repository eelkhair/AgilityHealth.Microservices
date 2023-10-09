using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Shared.Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.MasterTagCategories;

public class GetMasterTagCategoryQuery : BaseQuery<MasterTagCategoryDto>
{
    public Guid Uid { get; }

    public GetMasterTagCategoryQuery(ClaimsPrincipal user, ILogger logger,  Guid uid) : base(user, logger)
    {
        Uid = uid;
    }
}

public class GetMasterTagCategoryQueryHandler : BaseQueryHandler, IRequestHandler<GetMasterTagCategoryQuery, MasterTagCategoryDto>
{
    public GetMasterTagCategoryQueryHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<MasterTagCategoryDto> Handle(GetMasterTagCategoryQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting master tag category with uid {Uid}", request.Uid);
        var masterTagCategory = await Context.MasterTagCategories.Where(x=> x.UId == request.Uid).Include(x=> x.MasterTags).FirstOrDefaultAsync(cancellationToken);
        
        return Mapper.Map<MasterTagCategoryDto>(masterTagCategory);
    }
}

