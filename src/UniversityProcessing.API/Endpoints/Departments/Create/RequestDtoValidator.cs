using FluentValidation;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.Endpoints.Departments.Create;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
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
