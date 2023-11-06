using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Shared.Application.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTagCategories;

public class UpdateMasterTagCategoryCommand : BaseCommand<Unit>
{
    public MasterTagCategoryDto MasterTagCategory { get; }
    public string Domain { get; }
        
    public UpdateMasterTagCategoryCommand(ClaimsPrincipal user, ILogger logger , MasterTagCategoryDto masterTagCategory, string domain) : base(user, logger)
    {
        MasterTagCategory = masterTagCategory;
        Domain = domain;
    }
}

public class UpdateMasterTagCategoryCommandHandler : BaseCommandHandler,
    IRequestHandler<UpdateMasterTagCategoryCommand, Unit>
{
    public UpdateMasterTagCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper) : base(context,
        mapper)
    {
    }

    public async Task<Unit> Handle(UpdateMasterTagCategoryCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        
        var entity = await Context.MasterTagCategories.FirstAsync(x=> x.UId == request.MasterTagCategory.UId, cancellationToken);
        entity.ClassName = request.MasterTagCategory.ClassName;
        entity.Name = request.MasterTagCategory.Name;
        entity.Type = request.MasterTagCategory.Type == "All" ?string.Empty: request.MasterTagCategory.Type;
        Context.Update(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Unit.Value;
    }
}