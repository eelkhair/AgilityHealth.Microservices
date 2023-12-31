﻿using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Domains;

public class CreateDomainCommand(ClaimsPrincipal user, ILogger logger, DomainDto domain)
    : BaseCommand<DomainDto>(user, logger)
{
    public DomainDto Domain { get; } = domain;
}

public class CreateDomainCommandHandler(IMetadataDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<CreateDomainCommand, DomainDto>
{
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