using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AH.Shared.Application.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Companies;

public class UpdateCompanyCommand : BaseCommand<CompanyDto>
{
    public UpdateCompanyCommand(ClaimsPrincipal user, ILogger logger, CompanyDto company) : base(user, logger)
    {
        Company = company;
    }

    public CompanyDto Company { get; }
}

public class UpdateCompanyCommandHandler : BaseCommandHandler, IRequestHandler<UpdateCompanyCommand, CompanyDto>
{
    public UpdateCompanyCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<CompanyDto> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await Context.Companies.FirstAsync(x=> x.UId == request.Company.UId, cancellationToken);
        
        company.Name = request.Company.Name;
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<CompanyDto>(company);
    }
}

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator(IMetadataDbContext context)
    {
        RuleFor(x => x.Company.Name).NotEmpty()
            .WithMessage(ValidationMessages.CompanyNameNotEmpty);    
        RuleFor(x => x.Company.Name).MaximumLength(250)
            .WithMessage(ValidationMessages.CompanyNameMaxLength);
        RuleFor(x=>x.Company.UId).NotEmpty()
            .WithMessage(ValidationMessages.CompanyUIdNotEmpty);
        RuleFor(x => x.Company.UId).Must(uid =>
        {
            var company = context.Companies.FirstOrDefault(x => x.UId == uid);
            return company != null;
        }).WithMessage(ValidationMessages.CompanyUIdDoesNotExist);
            
            
    }
}