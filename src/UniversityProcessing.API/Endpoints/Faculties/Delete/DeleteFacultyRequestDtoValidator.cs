using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Faculties.Delete;

public sealed class DeleteFacultyRequestDtoValidator : AbstractValidator<DeleteFacultyRequestDto>
{
    public DeleteFacultyRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
