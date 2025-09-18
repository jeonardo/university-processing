using FluentValidation;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableGroups;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Number is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
