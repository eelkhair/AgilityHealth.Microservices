using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Shared.Application.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTagCategories;

public class DeleteMasterTagCategoryCommand : BaseCommand<Unit>
{
    public MasterTagCategoryDto MasterTagCategory { get; }
    public string Domain { get; }

    public DeleteMasterTagCategoryCommand(ClaimsPrincipal user, ILogger logger, MasterTagCategoryDto masterTagCategory, string domain) : base(user, logger)
    {
        MasterTagCategory = masterTagCategory;
        Domain = domain;
    }
}

public class DeleteMasterTagCategoryCommandHandler : BaseCommandHandler, IRequestHandler<DeleteMasterTagCategoryCommand, Unit>
{
    public DeleteMasterTagCategoryCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Unit> Handle(DeleteMasterTagCategoryCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        
        var entity = await Context.MasterTagCategories.FirstAsync(x => x.UId == request.MasterTagCategory.UId, cancellationToken);
        Context.MasterTagCategories.Remove(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Unit.Value;
    }
}