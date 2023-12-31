﻿using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.MasterTagCategories;

public class CreateMasterTagCategoryCommand(ClaimsPrincipal user, ILogger logger, MasterTagCategoryDto dto)
    : BaseCommand<MasterTagCategoryDto>(user, logger)
{
    public MasterTagCategoryDto MasterTagCategory { get; } = dto;
}

public class CreateMasterTagCategoryCommandHandler(IMetadataDbContext context, IMapper mapper)
    : BaseCommandHandler(context, mapper), IRequestHandler<CreateMasterTagCategoryCommand, MasterTagCategoryDto>
{
    public async Task<MasterTagCategoryDto> Handle(CreateMasterTagCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = Mapper.Map<MasterTagCategory>(request.MasterTagCategory);
        if (entity.Type == "All") entity.Type = string.Empty;
        
        await Context.MasterTagCategories.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(request.User,cancellationToken);
        return Mapper.Map<MasterTagCategoryDto>(entity);
    }
}

public class CreateMasterTagCategoryCommandValidator : AbstractValidator<CreateMasterTagCategoryCommand>
{
    public CreateMasterTagCategoryCommandValidator()
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
        
    }
}