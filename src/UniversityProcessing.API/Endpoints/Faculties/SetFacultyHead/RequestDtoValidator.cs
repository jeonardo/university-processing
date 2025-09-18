using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Faculties.SetFacultyHead;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
    {
        RuleFor(x => x.FacultyId)
            .NotEmpty()
            .WithMessage("Faculty is required");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User is required");
    }
}
