using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Companies;

public class CreateCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto company)
    : BaseCommand<CompanyDto>(user, logger)
{
    public CompanyDto Company { get; } = company;
}

public class CreateCompanyCommandHandler(IMetadataDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<CreateCompanyCommand, CompanyDto>
{
    public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var domainId = await Context.Domains.Where(x => x.UId == request.Company.Domain.UId)
            .Select(x => x.Id).FirstAsync(cancellationToken);
        
        var company = Mapper.Map<Domain.Entities.Company>(request.Company);
        company.DomainId = domainId;
        
        Context.Companies.Add(company);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<CompanyDto>(company);
    }
}

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator(IMetadataDbContext context)
    {
        RuleFor(x => x.Company.Name).NotEmpty()
            .WithMessage(ValidationMessages.CompanyNameNotEmpty);    
        RuleFor(x => x.Company.Name).MaximumLength(250)
            .WithMessage(ValidationMessages.CompanyNameMaxLength);
        RuleFor(x=> x.Company.Domain.UId).NotEmpty()
            .WithMessage(ValidationMessages.CompanyDomainUIdNotEmpty);
        RuleFor(x => x.Company.Domain.UId).Must(uid =>
        {
            var domain = context.Domains.FirstOrDefault(x => x.UId == uid);
            return domain != null;
        }).WithMessage(ValidationMessages.CompanyDomainUIdNotFound);
    }
}