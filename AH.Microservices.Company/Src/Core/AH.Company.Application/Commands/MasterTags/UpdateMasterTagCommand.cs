using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTags;

public class UpdateMasterTagCommand : BaseCommand<Unit>
{
    public MasterTagDto MasterTag { get; }
    public string Domain { get; }
        
    public UpdateMasterTagCommand(ClaimsPrincipal user, ILogger logger , MasterTagDto masterTag, string domain) : base(user, logger)
    {
        MasterTag = masterTag;
        Domain = domain;
    }
}

public class UpdateMasterTagCommandHandler : BaseCommandHandler,
    IRequestHandler<UpdateMasterTagCommand, Unit>
{
    public UpdateMasterTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper) : base(context,
        mapper)
    {
    }

    public async Task<Unit> Handle(UpdateMasterTagCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);

        var category =
            await Context.MasterTagCategories.FirstAsync(x => x.UId == request.MasterTag.MasterTagCategory.UId,
                cancellationToken);
        
        MasterTag? parentMasterTag = null;
        if (request.MasterTag.ParentMasterTag != null)
        {
            parentMasterTag = await Context.MasterTags.FirstAsync(x => x.UId == request.MasterTag.ParentMasterTag.UId,
                cancellationToken);
            
        }
        
        var entity = await Context.MasterTags.FirstAsync(x => x.UId == request.MasterTag.UId,
            cancellationToken: cancellationToken);
   
        entity.Name = request.MasterTag.Name;
        entity.ClassName = request.MasterTag.ClassName;
        entity.MasterTagCategoryId = category.Id;
        entity.MasterTagCategory = null!;
        entity.ParentMasterTagId = parentMasterTag?.Id ?? 0;
        
        Context.Update(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Unit.Value;
    }
}