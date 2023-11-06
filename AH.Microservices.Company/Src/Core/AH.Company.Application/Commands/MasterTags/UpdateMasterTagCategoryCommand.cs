using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Shared.Application.Commands;
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
        
        var entity = await Context.MasterTags.FirstAsync(x=> x.UId == request.MasterTag.UId, cancellationToken);
        Mapper.Map(request.MasterTag, entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Unit.Value;
    }
}