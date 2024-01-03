using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.MasterTagCategories;

public class UpdateMasterTagCategoryCommand(
    ClaimsPrincipal user,
    ILogger logger,
    MasterTagCategoryDto masterTagCategoryDto)
    : BaseCommand<MasterTagCategoryDto>(user, logger)
{
    public MasterTagCategoryDto MasterTagCategory{ get; } = masterTagCategoryDto;
}

public class UpdateMasterTagCategoryCommandHandler(IMetadataDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<UpdateMasterTagCategoryCommand, MasterTagCategoryDto>
{
    public async Task<MasterTagCategoryDto> Handle(UpdateMasterTagCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await Context.MasterTagCategories.FirstAsync(x=> x.UId == request.MasterTagCategory.UId, cancellationToken);
        Mapper.Map(request.MasterTagCategory, entity);
        if (entity.Type == "All") entity.Type = string.Empty;
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<MasterTagCategoryDto>(entity);
    }
}

public class UpdateMasterTagCategoryCommandValidator : AbstractValidator<UpdateMasterTagCategoryCommand>
{
    public UpdateMasterTagCategoryCommandValidator(IMetadataDbContext context)
    {
        RuleFor(x => x.MasterTagCategory.Name).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagCategoryNameRequired);
        RuleFor(x => x.MasterTagCategory.Name).MaximumLength(250)
            .WithMessage(ValidationMessages.MasterTagCategoryNameMaxLength);
        RuleFor(x => x.MasterTagCategory.ClassName).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagCategoryClassNameRequired);
        RuleFor(x => x.MasterTagCategory.Type).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagCategoryTypeRequired);

        var validTypes = new List<string>
        {
            MasterTagCategoryTypes.Individual, MasterTagCategoryTypes.Team, MasterTagCategoryTypes.MultiTeam,
            MasterTagCategoryTypes.Enterprise, "All"
        };
        
        RuleFor(x => x.MasterTagCategory.Type).Must(x => validTypes.Contains(x))
            .WithMessage(ValidationMessages.MasterTagCategoryTypeInvalid);

        var validClassNames = new List<string>
        {
            MasterTagCategoryClassNames.MasterStakeholderCategory, MasterTagCategoryClassNames.MasterSkillsCategory,
            MasterTagCategoryClassNames.MasterTeamCategory, MasterTagCategoryClassNames.MasterTeamMemberCategory
        };
        
        RuleFor(x => x.MasterTagCategory.ClassName).Must(x => validClassNames.Contains(x))
            .WithMessage(ValidationMessages.MasterTagCategoryClassNameInvalid);
        
        RuleFor(x=>x.MasterTagCategory.UId).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagCategoryUIdNotEmpty);
        
        RuleFor(x=>x.MasterTagCategory.UId).Must(uid =>
        {
            var category = context.MasterTagCategories.FirstOrDefault(x=> x.UId == uid);
            return category != null;
        }).WithMessage(ValidationMessages.MasterTagCategoryUIdDoesNotExist);
    }
}