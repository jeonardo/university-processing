using FluentValidation;
using Microsoft.Extensions.Options;
using UniversityProcessing.Infrastructure.Options;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Register.Admin;

public sealed class RegisterAdminRequestDtoValidator : AbstractValidator<RegisterAdminRequestDto>
{
    public RegisterAdminRequestDtoValidator(IOptions<IdentitySettings> options)
    {
        Include(new BaseRegisterRequestDtoValidator(options));
    }
}
