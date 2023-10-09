using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AH.Shared.Application.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Domains;

public class CreateDomainCommand : BaseCommand<DomainDto>
{
    public DomainDto Domain { get; }

    public CreateDomainCommand(ClaimsPrincipal user, ILogger logger, DomainDto domain ) : base(user, logger)
    {
        Domain = domain;
    }
}

public class CreateDomainCommandHandler : BaseCommandHandler, IRequestHandler<CreateDomainCommand, DomainDto>
{
        public CreateDomainCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public  async Task<DomainDto> Handle(CreateDomainCommand request, CancellationToken cancellationToken)
    {
        var domain = Mapper.Map<Domain.Entities.Domain>(request.Domain);
        await Context.Domains.AddAsync(domain, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<DomainDto>(domain);
    }
}

public class CreateDomainCommandValidator : AbstractValidator<CreateDomainCommand>
{
    public CreateDomainCommandValidator()
    {
        RuleFor(x => x.Domain.Name).NotEmpty()
            .WithMessage(ValidationMessages.DomainNameNotEmpty);    
        RuleFor(x => x.Domain.Name).MaximumLength(250)
            .WithMessage(ValidationMessages.DomainNameMaxLength);
    }
}