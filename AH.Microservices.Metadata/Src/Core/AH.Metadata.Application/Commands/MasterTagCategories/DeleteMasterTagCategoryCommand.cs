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

namespace AH.Metadata.Application.Commands.MasterTagCategories;

public class DeleteMasterTagCategoryCommand : BaseCommand<MasterTagCategoryDto>
{
    public Guid UId { get; }

    public DeleteMasterTagCategoryCommand(ClaimsPrincipal user, ILogger logger, Guid uId) : base(user, logger)
    {
        UId = uId;
    }
}

public class DeleteMasterTagCategoryCommandHandler : BaseCommandHandler, IRequestHandler<DeleteMasterTagCategoryCommand, MasterTagCategoryDto>
{
    public DeleteMasterTagCategoryCommandHandler(IMetadataDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<MasterTagCategoryDto> Handle(DeleteMasterTagCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await Context.MasterTagCategories.FirstAsync(x => x.UId == request.UId, cancellationToken);
        Context.MasterTagCategories.Remove(entity);
        await Context.SaveChangesAsync(request.User, cancellationToken);
        return Mapper.Map<MasterTagCategoryDto>(entity);
        
    }
}

public class DeleteMasterTagCategoryCommandValidator : AbstractValidator<DeleteMasterTagCategoryCommand>
{
    public DeleteMasterTagCategoryCommandValidator(IMetadataDbContext context)
    {
        RuleFor(x => x.UId).NotEmpty()
            .WithMessage(ValidationMessages.MasterTagCategoryUIdNotEmpty);
        RuleFor(x => x.UId).Must(uid =>
        {
            var masterTagCategory = context.MasterTagCategories.FirstOrDefault(x => x.UId == uid);
            return masterTagCategory != null;
        }).WithMessage(ValidationMessages.MasterTagCategoryUIdDoesNotExist);
    }
}