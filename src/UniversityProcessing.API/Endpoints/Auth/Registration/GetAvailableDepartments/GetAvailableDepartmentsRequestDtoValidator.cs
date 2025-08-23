using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableDepartments;

public sealed class GetAvailableDepartmentsRequestDtoValidator : AbstractValidator<GetAvailableDepartmentsRequestDto>
{
    public GetAvailableDepartmentsRequestDtoValidator()
    {
        RuleFor(x => x.FacultyId)
            .NotEmpty()
            .WithMessage("Faculty is required");
    }
}
