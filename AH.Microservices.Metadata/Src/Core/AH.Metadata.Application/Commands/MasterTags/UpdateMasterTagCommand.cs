using System.Security.Claims;
using System.Xml;
using AH.Metadata.Application.Dtos;
using AH.Metadata.Application.Interfaces;
using AH.Metadata.Domain.Constants;
using AH.Metadata.Domain.Entities;
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
        var category =
             await Context.MasterTagCategories.FirstAsync(x => x.UId == request.MasterTag.MasterTagCategory.UId,
                 cancellationToken);
        
        MasterTag? parentMasterTag = null;
        if (request.MasterTag.ParentMasterTag != null)
        {
             parentMasterTag = await Context.MasterTags.FirstAsync(x => x.UId == request.MasterTag.ParentMasterTag.UId,
                cancellationToken);
            
        }
        
        var entity = await Context.MasterTags.FirstAsync(x => x.UId == request.MasterTag.UId,
            cancellationToken: cancellationToken);
   
        entity.Name = request.MasterTag.Name;
        entity.ClassName = request.MasterTag.ClassName;
        entity.MasterTagCategoryId = category.Id;
        entity.MasterTagCategory = null!;
        entity.ParentMasterTagId = parentMasterTag?.Id ?? 0;
        
        Context.Update(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);

        var output = Mapper.Map<MasterTagDto>(entity);
        output.MasterTagCategory = Mapper.Map<MasterTagCategoryDto>(category);
        if (entity.ParentMasterTagId is null or 0) return output;
        output.ParentMasterTag = Mapper.Map<MasterTagDto>(parentMasterTag);

        return output;

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