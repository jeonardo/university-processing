using FluentValidation;
using Microsoft.Extensions.Options;
using UniversityProcessing.Infrastructure.Options;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register.Deanery;

public sealed class RegisterDeaneryRequestDtoValidator : AbstractValidator<RegisterDeaneryRequestDto>
{
    public RegisterDeaneryRequestDtoValidator(IOptions<IdentitySettings> options)
    {
        Include(new BaseRegisterRequestDtoValidator(options));

        RuleFor(x => x.UniversityPositionId)
            .NotEmpty()
            .WithMessage("UniversityPosition is required");

        RuleFor(x => x.FacultyId)
            .NotEmpty()
            .WithMessage("Faculty is required");
    }
}
