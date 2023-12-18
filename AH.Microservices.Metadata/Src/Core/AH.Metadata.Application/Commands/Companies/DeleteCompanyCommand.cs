using System.Security.Claims;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Companies;

public class DeleteCompanyCommand : BaseCommand<Unit>
{
    public Guid Uid { get; }
    public DeleteCompanyCommand(ClaimsPrincipal user, ILogger logger, Guid uid) : base(user, logger)
    {
        Uid = uid;
    }
}

public class DeleteCompanyCommandHandler : BaseCommandHandler, IRequestHandler<DeleteCompanyCommand, Unit>
{
    public DeleteCompanyCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await Context.Companies.FirstAsync(x => x.UId == request.Uid, cancellationToken);
        Context.Companies.Remove(company);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Unit.Value;
    }
}

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator(IMetadataDbContext context)
    {
        RuleFor(x => x.Uid).NotEmpty()
            .WithMessage(ValidationMessages.CompanyUIdNotEmpty);
        RuleFor(x => x.Uid).Must(uid =>
        {
            var company = context.Companies.FirstOrDefault(x => x.UId == uid);
            return company != null;
        }).WithMessage(ValidationMessages.CompanyUIdDoesNotExist);
    }
}