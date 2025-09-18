using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableDepartments;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
    {
        RuleFor(x => x.FacultyId)
            .NotEmpty()
            .WithMessage("Faculty is required");
    }
}
