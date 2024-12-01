using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Admin.Universities.Delete;

public sealed class DeleteUniversityRequestDtoValidator : AbstractValidator<DeleteUniversityRequestDto>
{
    public DeleteUniversityRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
