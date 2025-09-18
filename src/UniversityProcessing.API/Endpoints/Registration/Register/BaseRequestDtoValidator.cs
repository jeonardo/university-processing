using FluentValidation;
using Microsoft.Extensions.Options;
using UniversityProcessing.Infrastructure.Options;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.Endpoints.Registration.Register;

public sealed class BaseRequestDtoValidator : AbstractValidator<BaseRequestDto>
{
    public BaseRequestDtoValidator(IOptions<IdentitySettings> options)
    {
        var settings = options.Value;

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Email must be valid. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(
                $"Password is required. Min length = {settings.RequiredLength};{
                    (settings.RequireUppercase ? " RequireUppercase;" : "")}{
                        (settings.RequireLowercase ? " RequireLowercase;" : "")}{
                            (settings.RequireNonAlphanumeric ? " RequireNonAlphanumeric;" : "")}{
                                (settings.RequireDigit ? " RequireDigit;" : "")}");

        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("UserName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("FirstName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("LastName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.MiddleName)
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("MiddleName must be valid. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("PhoneNumber must be valid. Max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
