using FluentValidation;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.API.Endpoints.Admin.Faculties.Create;

public sealed class CreateFacultyRequestDtoValidator : AbstractValidator<CreateFacultyRequestDto>
{
    public CreateFacultyRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("ShortName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
