using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
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
        return Unit.Value;
       
    }
}

