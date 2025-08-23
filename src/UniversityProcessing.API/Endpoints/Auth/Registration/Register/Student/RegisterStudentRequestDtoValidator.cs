using FluentValidation;
using Microsoft.Extensions.Options;
using UniversityProcessing.Infrastructure.Options;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register.Student;

public sealed class RegisterStudentRequestDtoValidator : AbstractValidator<RegisterStudentRequestDto>
{
    public RegisterStudentRequestDtoValidator(IOptions<IdentitySettings> options)
    {
        Include(new BaseRegisterRequestDtoValidator(options));

        RuleFor(x => x.GroupNumber)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("GroupNumber is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
