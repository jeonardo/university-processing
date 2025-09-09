using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Specialties.Delete;

public sealed class DeleteSpecialtyRequestDtoValidator : AbstractValidator<DeleteSpecialtyRequestDto>
{
    public DeleteSpecialtyRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
