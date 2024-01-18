using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTagCategories;

public class CreateMasterTagCategoryCommand(
    ClaimsPrincipal user,
    ILogger logger,
    MasterTagCategoryDto masterTagCategory,
    string domain)
    : BaseCommand<Unit>(user, logger)
{
    public MasterTagCategoryDto MasterTagCategory { get; } = masterTagCategory;
    public string Domain { get; } = domain;
}

public class CreateMasterTagCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper, IMediator mediator)
    : BaseCommandHandler(context,
            mapper),
        IRequestHandler<CreateMasterTagCategoryCommand, Unit>
{
    private IMediator Mediator { get; } = mediator;

    public async Task<Unit> Handle(CreateMasterTagCategoryCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        var masterTagCategory = Mapper.Map<MasterTagCategory>(request.MasterTagCategory);
        
        request.Logger.LogInformation("Creating master tag category with name {Name} for domain {Domain}", masterTagCategory.Name, request.Domain);
        await Context.MasterTagCategories.AddAsync(masterTagCategory, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        request.Logger.LogInformation("Created master tag category with name {Name} for domain {Domain}", masterTagCategory.Name, request.Domain);

        await Mediator.Send(new CreateCompanyCategoriesFromMasterCategoryCommand(request.User, request.Logger,
            Mapper.Map<MasterTagCategoryDto>(masterTagCategory), request.Domain), cancellationToken);
        return Unit.Value;
       
    }
}

