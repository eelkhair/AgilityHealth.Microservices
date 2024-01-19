using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.MasterTags;

public class DeleteMasterTagCommand(ClaimsPrincipal user, ILogger logger, MasterTagDto masterTag, string domain)
    : BaseCommand<Unit>(user, logger)
{
    public MasterTagDto MasterTag{ get; } = masterTag;
    public string Domain { get; } = domain;
}

public class DeleteMasterTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper, IMediator mediator)
    : BaseCommandHandler(context, mapper), IRequestHandler<DeleteMasterTagCommand, Unit>
{
    public IMediator Mediator { get; } = mediator;

    public async Task<Unit> Handle(DeleteMasterTagCommand request, CancellationToken cancellationToken)
    {
        SetConnectionString(request.Domain, request.Logger);
        
        var entity = await Context.MasterTags.FirstAsync(x => x.UId == request.MasterTag.UId, cancellationToken);
        Context.MasterTags.Remove(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        await Mediator.Send(new DeleteCompanyTagsFromMasterTagCommand(request.User, request.Logger,
            Mapper.Map<MasterTagDto>(entity), request.Domain), cancellationToken);
        return Unit.Value;
    }
}