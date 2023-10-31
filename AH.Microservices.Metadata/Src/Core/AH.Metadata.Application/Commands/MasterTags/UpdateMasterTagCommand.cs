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

namespace AH.Metadata.Application.Commands.MasterTags;

public class UpdateMasterTagCommand : BaseCommand<MasterTagDto>
{
    public MasterTagDto MasterTag { get; }

    public UpdateMasterTagCommand(ClaimsPrincipal user, ILogger logger, MasterTagDto masterTag) : base(user, logger)
    {
        MasterTag = masterTag;
    }
}

public class UpdateMasterTagCommandHandler : BaseCommandHandler, IRequestHandler<UpdateMasterTagCommand, MasterTagDto>
{
    public UpdateMasterTagCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<MasterTagDto> Handle(UpdateMasterTagCommand request, CancellationToken cancellationToken)
    {
        var entity = await Context.MasterTags.FirstOrDefaultAsync(x=> x.UId ==request.MasterTag.UId, cancellationToken: cancellationToken);
        Mapper.Map(request.MasterTag, entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<MasterTagDto>(entity);
    }
}

public class UpdateMasterTagCommandValidator : AbstractValidator<UpdateMasterTagCommand>
{
    public UpdateMasterTagCommandValidator(IMetadataDbContext context)
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
        RuleFor(x=>x.MasterTag.UId).Must(x=>context.MasterTags.Any(y=>y.UId == x))
            .WithMessage(ValidationMessages.MasterTagUIdDoesNotExist);
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