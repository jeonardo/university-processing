using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Faculties.SetFacultyHead;

public sealed class SetFacultyHeadRequestDtoValidator : AbstractValidator<SetFacultyHeadRequestDto>
{
    public SetFacultyHeadRequestDtoValidator()
    {
        RuleFor(x => x.FacultyId)
            .NotEmpty()
            .WithMessage("Faculty is required");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User is required");
    }
}
