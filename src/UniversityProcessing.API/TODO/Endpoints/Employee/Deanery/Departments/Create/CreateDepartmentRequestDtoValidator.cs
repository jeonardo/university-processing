using FluentValidation;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Deanery.Departments.Create;

public sealed class CreateDepartmentRequestDtoValidator : AbstractValidator<CreateDepartmentRequestDto>
{
    public CreateDepartmentRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("ShortName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.FacultyId)
            .NotEmpty()
            .WithMessage("Faculty is required");
    }
}
