using FluentValidation;
using Microsoft.Extensions.Options;
using UniversityProcessing.API.Endpoints.Auth.Registration.Register.Teacher;
using UniversityProcessing.Infrastructure.Options;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register.Student;

public sealed class RegisterTeacherRequestDtoValidator : AbstractValidator<RegisterTeacherRequestDto>
{
    public RegisterTeacherRequestDtoValidator(IOptions<IdentitySettings> options)
    {
        Include(new BaseRegisterRequestDtoValidator(options));

        RuleFor(x => x.UniversityPositionId)
            .NotEmpty()
            .WithMessage("UniversityPosition is required");

        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .WithMessage("Department is required");
    }
}
