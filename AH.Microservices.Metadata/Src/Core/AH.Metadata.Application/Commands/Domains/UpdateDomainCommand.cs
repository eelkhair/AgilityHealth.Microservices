using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.Domains;

public class UpdateDomainCommand(ClaimsPrincipal user, ILogger logger, DomainDto domain)
    : BaseCommand<DomainDto>(user, logger)
{
    public DomainDto Domain { get; } = domain;
}

public class UpdateDomainCommandHandler(IMetadataDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<UpdateDomainCommand, DomainDto>
{
    public async Task<DomainDto> Handle(UpdateDomainCommand request, CancellationToken cancellationToken)
    {
        var domain = await Context.Domains.Include(x=>x.Companies).FirstAsync(x=> x.UId == request.Domain.UId, cancellationToken);
        
        domain.Name = request.Domain.Name;
        
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<DomainDto>(domain);
    }
}

public class UpdateDomainCommandValidator : AbstractValidator<UpdateDomainCommand>
{
    public UpdateDomainCommandValidator(IMetadataDbContext context)
    {
        RuleFor(x => x.Domain.Name).NotEmpty()
            .WithMessage(ValidationMessages.DomainNameNotEmpty);    
        RuleFor(x => x.Domain.Name).MaximumLength(250)
            .WithMessage(ValidationMessages.DomainNameMaxLength);
        RuleFor(x=> x.Domain.UId).NotEmpty()
            .WithMessage(ValidationMessages.DomainUIdNotEmpty);
        RuleFor(x=>x.Domain.UId).Must(uid =>
        {
            var domain = context.Domains.FirstOrDefault(x=> x.UId == uid);
            return domain != null;
        }).WithMessage(ValidationMessages.DomainUIdDoesNotExist);
     
    }
}