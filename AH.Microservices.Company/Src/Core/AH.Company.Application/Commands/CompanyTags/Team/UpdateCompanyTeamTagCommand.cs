using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTags.Team;

public class UpdateCompanyTeamTagCommand(ClaimsPrincipal user, ILogger logger, CompanyTeamTagDto tag) : BaseCommand<CompanyTeamTagDto>(user, logger)
{
    public CompanyTeamTagDto Tag { get; } = tag;
}

public class UpdateCompanyTeamTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<UpdateCompanyTeamTagCommand, CompanyTeamTagDto>
{
    public async Task<CompanyTeamTagDto> Handle(UpdateCompanyTeamTagCommand request, CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Updating company team tag");
        
        var companyTeamTag = await Context.CompanyTeamTags.FirstAsync(x => x.UId == request.Tag.UId, cancellationToken);
        var companyTeamCategory = await Context.CompanyTeamCategories.FirstAsync(x => x.UId == request.Tag.CompanyTeamCategory!.UId, cancellationToken);
        
        MasterTag? masterTag = null;
        if (request.Tag.MasterTag != null && request.Tag.MasterTag.UId != Guid.Empty)
        {
             masterTag = await Context.MasterTags.FirstAsync(x => x.UId == request.Tag.MasterTag.UId, cancellationToken);
        }
        
        companyTeamTag.Name = request.Tag.Name;
        companyTeamTag.CompanyTeamCategoryId = companyTeamCategory.Id;
        companyTeamTag.MasterTagId = masterTag?.Id;
        
        await Context.SaveChangesAsync(request.User, cancellationToken);

        var itemInDb = await Context.CompanyTeamTags
            .Where(x => x.Id == companyTeamTag.Id)
            .Select(x => new CompanyTeamTag
            {
                Name = x.Name,
                MasterTag = x.MasterTag == null
                    ? null
                    : new MasterTag
                    {
                        Name = x.MasterTag.Name,
                        ClassName = x.MasterTag.ClassName,
                        MasterTagCategory = new MasterTagCategory
                        {
                            Name = x.MasterTag.MasterTagCategory.Name,
                            ClassName = x.MasterTag.MasterTagCategory.ClassName,
                            Type = x.MasterTag.MasterTagCategory.Type,
                            UId = x.MasterTag.MasterTagCategory.UId
                        },
                        UId = x.MasterTag.UId
                    },
                CompanyTeamCategory = new CompanyTeamCategory
                {
                    Name = x.CompanyTeamCategory.Name,
                    Type = x.CompanyTeamCategory.Type,
                    UId = x.CompanyTeamCategory.UId,
                    Company = new Domain.Entities.Company
                    {
                        Name = x.CompanyTeamCategory.Company.Name,
                        UId = x.CompanyTeamCategory.Company.UId
                    },
                    MasterTagCategory = x.CompanyTeamCategory.MasterTagCategory == null
                        ? null
                        : new MasterTagCategory
                        {
                            Name = x.CompanyTeamCategory.MasterTagCategory.Name,
                            ClassName = x.CompanyTeamCategory.MasterTagCategory.ClassName,
                            Type = x.CompanyTeamCategory.MasterTagCategory.Type,
                            UId = x.CompanyTeamCategory.MasterTagCategory.UId
                        }
                },
                UId = x.UId
            }).FirstAsync(cancellationToken);
        
        return Mapper.Map<CompanyTeamTagDto>(itemInDb);
    }
}