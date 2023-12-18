using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.MasterTags;

public class DeleteMasterTagCommand : BaseCommand<MasterTagDto>
{
    public Guid MasterTagUId { get; }

    public DeleteMasterTagCommand(ClaimsPrincipal user, ILogger logger, Guid masterTagUId) : base(user, logger)
    {
        MasterTagUId = masterTagUId;
    }
}

public class DeleteMasterTagCommandHandler : BaseCommandHandler, IRequestHandler<DeleteMasterTagCommand, MasterTagDto>
{
    public DeleteMasterTagCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<MasterTagDto> Handle(DeleteMasterTagCommand request, CancellationToken cancellationToken)
    {
        var entity = await Context.MasterTags.FirstAsync(x => x.UId == request.MasterTagUId, cancellationToken);
        Context.MasterTags.Remove(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<MasterTagDto>(entity);
    }
}

public class DeleteMasterTagCommandValidator : AbstractValidator<DeleteMasterTagCommand>
{
    public DeleteMasterTagCommandValidator(IMetadataDbContext context)
    {
        RuleFor(x => x.MasterTagUId).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagUIdNotEmpty);
        RuleFor(x => x.MasterTagUId).Must(uid =>
        {
            var masterTag = context.MasterTags.FirstOrDefault(x => x.UId == uid);
            return masterTag != null;
        }).WithMessage(ValidationMessages.MasterTagUIdDoesNotExist);
    }
}