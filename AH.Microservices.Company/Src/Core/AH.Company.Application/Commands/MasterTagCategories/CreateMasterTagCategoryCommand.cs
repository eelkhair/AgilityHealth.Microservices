using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AH.Shared.Application.Commands;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTagCategories;

public class CreateMasterTagCategoryCommand : BaseCommand<Unit>
{
    public MasterTagCategoryDto MasterTagCategory { get; }
    public string Domain { get; }

    public CreateMasterTagCategoryCommand(ClaimsPrincipal user, ILogger logger, MasterTagCategoryDto masterTagCategory, string domain) : base(user, logger)
    {
        MasterTagCategory = masterTagCategory;
        Domain = domain;
    }
}

public class CreateMasterTagCategoryCommandHandler : BaseCommandHandler,
    IRequestHandler<CreateMasterTagCategoryCommand, Unit>
{
    public CreateMasterTagCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper) : base(context,
        mapper)
    {
    }

    public async Task<Unit> Handle(CreateMasterTagCategoryCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        var masterTagCategory = Mapper.Map<MasterTagCategory>(request.MasterTagCategory);
        
        request.Logger.LogInformation("Creating master tag category with name {Name} for domain {Domain}", masterTagCategory.Name, request.Domain);
        await Context.MasterTagCategories.AddAsync(masterTagCategory, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        request.Logger.LogInformation("Created master tag category with name {Name} for domain {Domain}", masterTagCategory.Name, request.Domain);
        return Unit.Value;
       
    }
}

