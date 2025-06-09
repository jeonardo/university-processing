using FluentValidation;

namespace UniversityProcessing.API.TODO.Endpoints.Admin.Faculties.Delete;

public sealed class DeleteFacultyRequestDtoValidator : AbstractValidator<DeleteFacultyRequestDto>
{
    public DeleteFacultyRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
