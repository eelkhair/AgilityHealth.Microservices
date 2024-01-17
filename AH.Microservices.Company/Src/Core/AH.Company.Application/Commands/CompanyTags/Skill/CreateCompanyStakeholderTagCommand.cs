using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTags.Skill;

public class CreateCompanySkillTagCommand(ClaimsPrincipal user, ILogger logger, CompanySkillTagDto tag)
    : BaseCommand<CompanySkillTagDto>(user, logger)
{
    public CompanySkillTagDto Tag { get; } = tag;
}

public class CreateCompanySkillTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<CreateCompanySkillTagCommand, CompanySkillTagDto>
{
    public async Task<CompanySkillTagDto> Handle(CreateCompanySkillTagCommand request,
        CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Creating company skill tag");
        
        var companySkillCategory = await Context.CompanySkillCategories
            .FirstAsync(x => x.UId == request.Tag.CompanySkillCategory!.UId, cancellationToken);
        
        MasterTag? masterTag = null;
        if (request.Tag.MasterTag != null && request.Tag.MasterTag.UId != Guid.Empty)
        {
            masterTag = await Context.MasterTags.FirstAsync(x => x.UId == request.Tag.MasterTag.UId, cancellationToken);
        }
        var companySkillTag = new CompanySkillTag
        {
            Name = request.Tag.Name,
            CompanySkillCategory = companySkillCategory,
            MasterTagId = masterTag?.Id
        };
        await Context.CompanySkillTags.AddAsync(companySkillTag, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        
        var itemInDb = await Context.CompanySkillTags
            .Where(x => x.Id == companySkillTag.Id)
            .Select(x=> new CompanySkillTag
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
                CompanySkillCategory = new CompanySkillCategory
                {
                    Name = x.CompanySkillCategory.Name,
                    Type = x.CompanySkillCategory.Type,
                    UId = x.CompanySkillCategory.UId,
                    Company = new Domain.Entities.Company
                    {
                        Name = x.CompanySkillCategory.Company.Name,
                        UId = x.CompanySkillCategory.Company.UId
                    },
                    MasterTagCategory = x.CompanySkillCategory.MasterTagCategory == null ? null : new MasterTagCategory
                    {
                        Name = x.CompanySkillCategory.MasterTagCategory.Name,
                        ClassName = x.CompanySkillCategory.MasterTagCategory.ClassName,
                        Type = x.CompanySkillCategory.MasterTagCategory.Type,
                        UId = x.CompanySkillCategory.MasterTagCategory.UId
                    }
                },
                UId = x.UId
            }).FirstOrDefaultAsync(cancellationToken);
        
        return Mapper.Map<CompanySkillTagDto>(itemInDb!);
    }
}