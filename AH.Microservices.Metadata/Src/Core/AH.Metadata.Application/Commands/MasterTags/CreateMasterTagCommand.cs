using System.Security.Claims;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Domain.Entities;
using AH.Shared.Application.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AH.Metadata.Application.Commands.MasterTags;

public class CreateMasterTagCommand : BaseCommand<MasterTagDto>
{
    public MasterTagDto MasterTag { get; }

    public CreateMasterTagCommand(ClaimsPrincipal user, ILogger logger, MasterTagDto masterTag) : base(user, logger)
    {
        MasterTag = masterTag;
    }
}

public class CreateMasterTagCommandHandler : BaseCommandHandler, IRequestHandler<CreateMasterTagCommand, MasterTagDto>
{
    public CreateMasterTagCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<MasterTagDto> Handle(CreateMasterTagCommand request, CancellationToken cancellationToken)
    {
        var entity = Mapper.Map<MasterTag>(request.MasterTag);
        await Context.MasterTags.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<MasterTagDto>(entity);
    }
}

public class CreateMasterTagCommandValidator : AbstractValidator<CreateMasterTagCommand>
{
    public CreateMasterTagCommandValidator(IMetadataDbContext context)
    {
        RuleFor(x => x.MasterTag.Name).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagNameRequired);
        RuleFor(x => x.MasterTag.Name).MaximumLength(250)
            .WithMessage(ValidationMessages.MasterTagNameMaxLength);
        RuleFor(x => x.MasterTag.ClassName).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagClassNameRequired);
        RuleFor(x => x.MasterTag.MasterTagCategoryId).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagCategoryRequired);
        RuleFor(x=>x.MasterTag.MasterTagCategory.UId).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagCategoryRequired);
        RuleFor(x => x.MasterTag.MasterTagCategory.UId).Must(categoryUId =>
        {
            var category = context.MasterTagCategories.FirstOrDefault(x => x.UId == categoryUId);
            return category != null;
        }).WithMessage(ValidationMessages.MasterTagCategoryNotFound);
        When(x=>x.MasterTag.ParentMasterTag != null, () =>
        {
            RuleFor(x => x.MasterTag.ParentMasterTag!.UId).Must(parentMasterTagId =>
            {
                var parentMasterTag = context.MasterTags.FirstOrDefault(x => x.UId == parentMasterTagId);
                return parentMasterTag != null;
            }).WithMessage(ValidationMessages.MasterTagParentMasterTagNotFound);
        });
    }
}