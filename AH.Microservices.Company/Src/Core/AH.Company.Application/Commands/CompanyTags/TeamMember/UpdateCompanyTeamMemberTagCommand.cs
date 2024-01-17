using System.Security.Claims;
using AH.Company.Application.Dtos;
using AH.Company.Application.Interfaces;
using AH.Company.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Company.Application.Commands.CompanyTags.TeamMember;

public class UpdateCompanyTeamMemberTagCommand(ClaimsPrincipal user, ILogger logger, CompanyTeamMemberTagDto tag) : BaseCommand<CompanyTeamMemberTagDto>(user, logger)
{
    public CompanyTeamMemberTagDto Tag { get; } = tag;
}

public class UpdateCompanyTeamMemberTagCommandHandler(ICompanyMicroServiceDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper),
        IRequestHandler<UpdateCompanyTeamMemberTagCommand, CompanyTeamMemberTagDto>
{
    public async Task<CompanyTeamMemberTagDto> Handle(UpdateCompanyTeamMemberTagCommand request,
        CancellationToken cancellationToken)
    {
        request.Logger.LogInformation("Connections string: {ConnectionString}", Context.GetConnectionString());
        request.Logger.LogInformation("Updating company team member tag");

        var teamMemberCategory =
            await Context.CompanyTeamMemberCategories.FirstAsync(
                x => x.UId == request.Tag.CompanyTeamMemberCategory.UId, cancellationToken);

        MasterTag? masterTag = null;
        CompanyTeamTag? companyTeamTag = null;

        if (request.Tag.MasterTag != null)
        {
            masterTag = await Context.MasterTags.FirstOrDefaultAsync(x => x.UId == request.Tag.MasterTag.UId,
                cancellationToken);
        }

        if (request.Tag.CompanyTeamTag != null)
        {
            companyTeamTag =
                await Context.CompanyTeamTags.FirstOrDefaultAsync(x => x.UId == request.Tag.CompanyTeamTag.UId,
                    cancellationToken);
        }

        var companyTeamMemberTag =
            await Context.CompanyTeamMemberTags.FirstAsync(x => x.UId == request.Tag.UId, cancellationToken);

        companyTeamMemberTag.Name = request.Tag.Name;
        companyTeamMemberTag.CompanyTeamMemberCategoryId = teamMemberCategory.Id;
        companyTeamMemberTag.MasterTagId = masterTag?.Id;
        companyTeamMemberTag.CompanyTeamTagId = companyTeamTag?.Id;

        await Context.SaveChangesAsync(request.User, cancellationToken);

         var itemInDb = await Context.CompanyTeamMemberTags
            .Where(x => x.UId == companyTeamMemberTag.UId)
            .Select(x => new CompanyTeamMemberTag
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
                CompanyTeamTag = x.CompanyTeamTag == null
                    ? null
                    : new CompanyTeamTag
                    {
                        Name = x.CompanyTeamTag.Name,
                        CompanyTeamCategory = new CompanyTeamCategory
                        {
                            Name = x.CompanyTeamTag.CompanyTeamCategory.Name,
                            Type = x.CompanyTeamTag.CompanyTeamCategory.Type,
                            UId = x.CompanyTeamTag.CompanyTeamCategory.UId,
                            Company = new Domain.Entities.Company
                            {
                                Name = x.CompanyTeamTag.CompanyTeamCategory.Company.Name,
                                UId = x.CompanyTeamTag.CompanyTeamCategory.Company.UId
                            },
                            MasterTagCategory = x.CompanyTeamTag.CompanyTeamCategory.MasterTagCategory == null
                                ? null
                                : new MasterTagCategory
                                {
                                    Name = x.CompanyTeamTag.CompanyTeamCategory.MasterTagCategory.Name,
                                    ClassName = x.CompanyTeamTag.CompanyTeamCategory.MasterTagCategory.ClassName,
                                    Type = x.CompanyTeamTag.CompanyTeamCategory.MasterTagCategory.Type,
                                    UId = x.CompanyTeamTag.CompanyTeamCategory.MasterTagCategory.UId
                                }
                        },
                        MasterTag = x.CompanyTeamTag.MasterTag == null
                            ? null
                            : new MasterTag
                            {
                                Name = x.CompanyTeamTag.MasterTag.Name,
                                ClassName = x.CompanyTeamTag.MasterTag.ClassName,

                                MasterTagCategory = new MasterTagCategory
                                {
                                    Name = x.CompanyTeamTag.MasterTag.MasterTagCategory.Name,
                                    ClassName = x.CompanyTeamTag.MasterTag.MasterTagCategory.ClassName,
                                    Type = x.CompanyTeamTag.MasterTag.MasterTagCategory.Type,
                                    UId = x.CompanyTeamTag.MasterTag.MasterTagCategory.UId
                                },
                                UId = x.CompanyTeamTag.MasterTag.UId
                            },
                        UId = x.CompanyTeamTag.UId
                    },
                CompanyTeamMemberCategory = new CompanyTeamMemberCategory
                {
                    Name = x.CompanyTeamMemberCategory.Name,
                    Type = x.CompanyTeamMemberCategory.Type,
                    UId = x.CompanyTeamMemberCategory.UId,
                    Company = new Domain.Entities.Company
                    {
                        Name = x.CompanyTeamMemberCategory.Company.Name,
                        UId = x.CompanyTeamMemberCategory.Company.UId
                    },
                    MasterTagCategory = x.CompanyTeamMemberCategory.MasterTagCategory == null
                        ? null
                        : new MasterTagCategory
                        {
                            Name = x.CompanyTeamMemberCategory.MasterTagCategory.Name,
                            ClassName = x.CompanyTeamMemberCategory.MasterTagCategory.ClassName,
                            Type = x.CompanyTeamMemberCategory.MasterTagCategory.Type,
                            UId = x.CompanyTeamMemberCategory.MasterTagCategory.UId
                        }
                },
                UId = x.UId
            }).FirstAsync(cancellationToken);

        return Mapper.Map<CompanyTeamMemberTagDto>(itemInDb);
    }
}

