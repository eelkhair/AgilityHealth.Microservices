using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Application.Resources;
using AH.Shared.Application.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Companies;

public class CreateCompanyCommand : BaseCommand<CompanyDto>
{
    public CompanyDto Company { get; }

    public CreateCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto company) : base(user, logger)
    {
        Company = company;
    }
}

public class CreateCompanyCommandHandler : BaseCommandHandler, IRequestHandler<CreateCompanyCommand, CompanyDto>
{
    public CreateCompanyCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

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
            .WithMessage(ValidationMessages.Company_NameNotEmpty);    
        RuleFor(x => x.Company.Name).MaximumLength(250)
            .WithMessage(ValidationMessages.Company_NameMaxLength);
        RuleFor(x=> x.Company.Domain.UId).NotEmpty()
            .WithMessage(ValidationMessages.Company_DomainUIdNotEmpty);
        RuleFor(x => x.Company.Domain.UId).Must(uid =>
        {
            var domain = context.Domains.FirstOrDefault(x => x.UId == uid);
            return domain != null;
        }).WithMessage(ValidationMessages.Company_DomainUIdNotFound);
    }
}