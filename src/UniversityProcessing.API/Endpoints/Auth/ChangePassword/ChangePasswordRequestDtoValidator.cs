using FluentValidation;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.Endpoints.Auth.ChangePassword;

public sealed class ChangePasswordRequestDtoValidator : AbstractValidator<ChangePasswordRequestDto>
{
    public ChangePasswordRequestDtoValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Password is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("NewPassword is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
