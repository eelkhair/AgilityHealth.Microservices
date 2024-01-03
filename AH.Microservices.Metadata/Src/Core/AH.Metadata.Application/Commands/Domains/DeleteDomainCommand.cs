using System.Security.Claims;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Domains;

public class DeleteDomainCommand(ClaimsPrincipal user, ILogger logger, Guid uid) : BaseCommand<Unit>(user, logger)
{
    public Guid Uid { get; } = uid;
}

public class DeleteDomainCommandHandler(IMetadataDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<DeleteDomainCommand, Unit>
{
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