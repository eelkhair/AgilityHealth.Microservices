using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTags.Stakeholder;

public class CreateCompanyStakeholderTagCommand(ClaimsPrincipal user, ILogger logger, CompanyStakeholderTagDto tag)
    : BaseCommand<CompanyStakeholderTagDto>(user, logger)
{
    public CompanyStakeholderTagDto Tag { get; } = tag;
}

public class CreateCompanyStakeholderTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<CreateCompanyStakeholderTagCommand, CompanyStakeholderTagDto>
{
    public async Task<CompanyStakeholderTagDto> Handle(CreateCompanyStakeholderTagCommand request,
        CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company stakeholder tag");
        
        var companyStakeholderCategory = await Context.CompanyStakeholderCategories
            .FirstAsync(x => x.UId == request.Tag.CompanyStakeholderCategory!.UId, cancellationToken);
        
        MasterTag? masterTag = null;
        if (request.Tag.MasterTag != null && request.Tag.MasterTag.UId != Guid.Empty)
        {
            masterTag = await Context.MasterTags.FirstAsync(x => x.UId == request.Tag.MasterTag.UId, cancellationToken);
        }
        var companyStakeholderTag = new CompanyStakeholderTag
        {
            Name = request.Tag.Name,
            CompanyStakeholderCategory = companyStakeholderCategory,
            MasterTagId = masterTag?.Id
        };
        await Context.CompanyStakeholderTags.AddAsync(companyStakeholderTag, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        var itemInDb = await Context.CompanyStakeholderTags
            .Where(x => x.Id == companyStakeholderTag.Id)
            .Select(x=> new CompanyStakeholderTag
            {
                Name = x.Name,
                MasterTag = x.MasterTag == null ? null : new MasterTag
                {
                    Name = x.MasterTag.Name,
                    ClassName = x.MasterTag.ClassName,
                    MasterTagCategory =  new MasterTagCategory
                    {
                        Name = x.MasterTag.MasterTagCategory.Name,
                        ClassName = x.MasterTag.MasterTagCategory.ClassName,
                        Type = x.MasterTag.MasterTagCategory.Type,
                        UId = x.MasterTag.MasterTagCategory.UId
                    },
                    UId = x.MasterTag.UId
                },
                CompanyStakeholderCategory = new CompanyStakeholderCategory
                {
                    Name = x.CompanyStakeholderCategory.Name,
                    Type = x.CompanyStakeholderCategory.Type,
                    UId = x.CompanyStakeholderCategory.UId,
                    Company = new Domain.Entities.Company
                    {
                        Name = x.CompanyStakeholderCategory.Company.Name,
                        UId = x.CompanyStakeholderCategory.Company.UId
                    },
                    MasterTagCategory = x.CompanyStakeholderCategory.MasterTagCategory == null ? null : new MasterTagCategory
                    {
                        Name = x.CompanyStakeholderCategory.MasterTagCategory.Name,
                        ClassName = x.CompanyStakeholderCategory.MasterTagCategory.ClassName,
                        Type = x.CompanyStakeholderCategory.MasterTagCategory.Type,
                        UId = x.CompanyStakeholderCategory.MasterTagCategory.UId
                    }
                },
                UId = x.UId
            }).FirstOrDefaultAsync(cancellationToken);
        
        return Mapper.Map<CompanyStakeholderTagDto>(itemInDb!);
    }
}