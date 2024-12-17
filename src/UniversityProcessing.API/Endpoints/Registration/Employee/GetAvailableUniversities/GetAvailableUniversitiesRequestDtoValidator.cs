using FluentValidation;
using UniversityProcessing.Domain.Validation;

namespace UniversityProcessing.API.Endpoints.Registration.Employee.GetAvailableUniversities;

public sealed class GetAvailableUniversitiesRequestDtoValidator : AbstractValidator<GetAvailableUniversitiesRequestDto>
{
    public GetAvailableUniversitiesRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
