using FluentValidation;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.Endpoints.Auth.Login;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("UserName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Password is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
