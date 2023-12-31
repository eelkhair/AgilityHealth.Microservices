﻿using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Companies;

public class DeleteCompanyCommand(ClaimsPrincipal user, ILogger logger, Guid uid) : BaseCommand<CompanyDto>(user, logger)
{
    public Guid Uid { get; } = uid;
}

public class DeleteCompanyCommandHandler(IMetadataDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<DeleteCompanyCommand, CompanyDto>
{
    public async Task<CompanyDto> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await Context.Companies.Include(x=>x.Domain).FirstAsync(x => x.UId == request.Uid, cancellationToken);
        Context.Companies.Remove(company);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<CompanyDto>(company) ;
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