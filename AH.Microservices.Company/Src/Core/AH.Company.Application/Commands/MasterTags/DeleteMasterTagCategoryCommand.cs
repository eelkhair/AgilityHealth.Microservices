using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Shared.Application.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTags;

public class DeleteMasterTagCommand : BaseCommand<Unit>
{
    public MasterTagDto MasterTag{ get; }
    public string Domain { get; }

    public DeleteMasterTagCommand(ClaimsPrincipal user, ILogger logger, MasterTagDto masterTag, string domain) : base(user, logger)
    {
        MasterTag = masterTag;
        Domain = domain;
    }
}

public class DeleteMasterTagCommandHandler : BaseCommandHandler, IRequestHandler<DeleteMasterTagCommand, Unit>
{
    public DeleteMasterTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Unit> Handle(DeleteMasterTagCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        
        var entity = await Context.MasterTags.FirstAsync(x => x.UId == request.MasterTag.UId, cancellationToken);
        Context.MasterTags.Remove(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Unit.Value;
    }
}