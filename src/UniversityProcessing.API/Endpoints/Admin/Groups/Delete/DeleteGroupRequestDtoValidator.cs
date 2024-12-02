using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Admin.Groups.Delete;

public sealed class DeleteGroupRequestDtoValidator : AbstractValidator<DeleteGroupRequestDto>
{
    public DeleteGroupRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
