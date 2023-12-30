using System.Security.Claims;
using AH.Metadata.Application.Commands;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Queries.MasterTags;

public class ListMasterTagsByCategoryQuery(ClaimsPrincipal user, ILogger logger, Guid masterCategoryUId)
    : BaseCommand<List<MasterTagDto>>(user, logger)
{
    public Guid MasterCategoryUId { get; } = masterCategoryUId;
}

public class ListMasterTagsByCategoryQueryHandler(IMetadataDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<ListMasterTagsByCategoryQuery, List<MasterTagDto>>
{
    public async Task<List<MasterTagDto>> Handle(ListMasterTagsByCategoryQuery request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Getting all master tags");
        return await Context.MasterTags.IgnoreQueryFilters()
            .Where(x => x.MasterTagCategory.UId == request.MasterCategoryUId 
                        && x.RecordStatus == RecordStatuses.Active
                        && x.MasterTagCategory.RecordStatus == RecordStatuses.Active)
            .Select(x => new MasterTagDto
            {
                ClassName = x.ClassName,
                Id = x.Id,
                Name = x.Name,
                UId = x.UId,
                MasterTagCategory = new MasterTagCategoryDto
                {
                    ClassName = x.MasterTagCategory.ClassName,
                    Id = x.MasterTagCategory.Id,
                    UId = x.MasterTagCategory.UId,
                    Type = x.MasterTagCategory.Type,
                    Name = x.MasterTagCategory.Name
                },
                ParentMasterTag = x.ParentMasterTag == null
                    ? null
                    : new MasterTagDto
                    {
                        Name = x.ParentMasterTag.Name,
                        Id = x.ParentMasterTag.Id,
                        ClassName = x.ParentMasterTag.ClassName,
                        UId = x.ParentMasterTag.UId,
                        MasterTagCategory = new MasterTagCategoryDto
                        {
                            Name = x.ParentMasterTag.MasterTagCategory.Name,
                            Id = x.ParentMasterTag.MasterTagCategoryId,
                            UId = x.ParentMasterTag.MasterTagCategory.UId,
                            ClassName = x.ParentMasterTag.MasterTagCategory.ClassName
                        }
                    }
            }).ToListAsync(cancellationToken);
    }
}