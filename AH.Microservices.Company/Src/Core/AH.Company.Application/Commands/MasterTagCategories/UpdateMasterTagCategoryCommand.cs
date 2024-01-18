using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTagCategories;

public class UpdateMasterTagCategoryCommand(
    ClaimsPrincipal user,
    ILogger logger,
    MasterTagCategoryDto masterTagCategory,
    string domain)
    : BaseCommand<Unit>(user, logger)
{
    public MasterTagCategoryDto MasterTagCategory { get; } = masterTagCategory;
    public string Domain { get; } = domain;
}

public class UpdateMasterTagCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper, IMediator mediator)
    : BaseCommandHandler(context,
            mapper),
        IRequestHandler<UpdateMasterTagCategoryCommand, Unit>
{
    private IMediator Mediator { get; } = mediator;

    public async Task<Unit> Handle(UpdateMasterTagCategoryCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        
        var entity = await Context.MasterTagCategories.FirstAsync(x=> x.UId == request.MasterTagCategory.UId, cancellationToken);
        var oldEntity = Mapper.Map<MasterTagCategoryDto>(entity);
        entity.ClassName = request.MasterTagCategory.ClassName;
        entity.Name = request.MasterTagCategory.Name;
        entity.Type = request.MasterTagCategory.Type == "All" ?string.Empty: request.MasterTagCategory.Type;
        Context.Update(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        await Mediator.Send(new UpdateCompanyCategoriesFromMasterCategoryCommand(request.User, request.Logger,
            Mapper.Map<MasterTagCategoryDto>(entity), oldEntity, request.Domain), cancellationToken);
        return Unit.Value;
    }
}