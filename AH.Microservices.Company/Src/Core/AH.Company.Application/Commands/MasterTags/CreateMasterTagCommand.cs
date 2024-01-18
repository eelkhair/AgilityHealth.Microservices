using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTags;

public class CreateMasterTagCommand(ClaimsPrincipal user, ILogger logger, MasterTagDto masterTag, string domain)
    : BaseCommand<Unit>(user, logger)
{
    public MasterTagDto MasterTag { get; } = masterTag;
    public string Domain { get; } = domain;
}

public class CreateMasterTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper, IMediator mediator) : BaseCommandHandler(
        context,
        mapper),
    IRequestHandler<CreateMasterTagCommand, Unit>
{
    public IMediator Mediator { get; } = mediator;

    public async Task<Unit> Handle(CreateMasterTagCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        var category = await Context.MasterTagCategories.FirstAsync(x => x.UId == request.MasterTag.MasterTagCategory.UId, cancellationToken);
        
        var entity = Mapper.Map<MasterTag>(request.MasterTag);
        entity.MasterTagCategoryId = category.Id;
        entity.MasterTagCategory = null!;
        
        MasterTag? parentMasterTag = null;
        if (request.MasterTag.ParentMasterTag != null)
        {
            parentMasterTag = await Context.MasterTags.FirstAsync(x => x.UId == request.MasterTag.ParentMasterTag.UId, cancellationToken);
        }
        entity.ParentMasterTagId = parentMasterTag?.Id;
        await Context.MasterTags.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        var updatedMapping = Mapper.Map<MasterTagDto>(entity);
        updatedMapping.MasterTagCategory = Mapper.Map<MasterTagCategoryDto>(category);
        updatedMapping.ParentMasterTag = Mapper.Map<MasterTagDto>(parentMasterTag);
        
        request.Logger.LogInformation("Updated mapping: {@UpdatedMapping}", updatedMapping);
        await Mediator.Send(new CreateCompanyTagsFromMasterTagCommand(request.User, request.Logger, updatedMapping, request.Domain), cancellationToken);
        return Unit.Value;
       
    }
}

