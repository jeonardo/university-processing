using FluentValidation;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.API.Endpoints.Admin.Periods.Create;

public sealed class CreatePeriodRequestDtoValidator : AbstractValidator<CreatePeriodRequestDto>
{
    public CreatePeriodRequestDtoValidator()
    {
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
