using FluentValidation;
using UniversityProcessing.Domain;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Specialties.Create;

public sealed class CreateSpecialtyRequestDtoValidator : AbstractValidator<CreateSpecialtyRequestDto>
{
    public CreateSpecialtyRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("ShortName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .WithMessage("Department is required");

        RuleFor(x => x.Code)
            .Length(Specialty.CODE_LENGTH)
            .WithMessage($"Code is required. Length must be {Specialty.CODE_LENGTH} characters long");
    }
}
