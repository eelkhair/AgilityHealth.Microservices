using System.Security.Claims;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AH.Shared.Application.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Domains;

public class DeleteDomainCommand : BaseCommand<Unit>
{
    public Guid Uid { get; }
    public DeleteDomainCommand(ClaimsPrincipal user, ILogger logger, Guid uid) : base(user, logger)
    {
        Uid = uid;
    }
}

public class DeleteDomainCommandHandler : BaseCommandHandler, IRequestHandler<DeleteDomainCommand, Unit>
{
    public DeleteDomainCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Unit> Handle(DeleteDomainCommand request, CancellationToken cancellationToken)
    {
        var domain = await Context.Domains.FirstAsync(x => x.UId == request.Uid, cancellationToken);
        Context.Domains.Remove(domain);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Unit.Value;
    }
}

public class DeleteDomainCommandValidator : AbstractValidator<DeleteDomainCommand>
{
    public DeleteDomainCommandValidator(IMetadataDbContext context)
    {
        RuleFor(x => x.Uid).NotEmpty()
            .WithMessage(ValidationMessages.DomainUIdNotEmpty);
        RuleFor(x => x.Uid).Must(uid =>
        {
            var domain = context.Domains.FirstOrDefault(x => x.UId == uid);
            return domain != null;
        }).WithMessage(ValidationMessages.DomainUIdDoesNotExist);
    }
}