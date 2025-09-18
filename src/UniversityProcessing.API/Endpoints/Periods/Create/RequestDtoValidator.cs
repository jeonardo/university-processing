using FluentValidation;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.Endpoints.Periods.Create;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.From)
            .NotEmpty()
            .WithMessage("From is required");

        RuleFor(x => x.To)
            .NotEmpty()
            .WithMessage("To is required");

        RuleFor(x => x.Comments)
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Comments max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
