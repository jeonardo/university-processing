using FluentValidation;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.Endpoints.Identity.RegisterUser;

public sealed class RegisterUserRequestDtoValidator : AbstractValidator<RegisterUserRequestDto>
{
    public RegisterUserRequestDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Username is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Password is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("First name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Last name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Email must be valid. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.MiddleName)
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("MiddleName must be valid. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Role)
            .NotEmpty()
            .IsInEnum()
            .WithMessage("Role is required");
    }
}
