using FluentValidation;
using Microsoft.Extensions.Options;
using UniversityProcessing.Infrastructure.Options;

namespace UniversityProcessing.API.Endpoints.Registration.Register.Admin;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator(IOptions<IdentitySettings> options)
    {
        Include(new BaseRequestDtoValidator(options));
    }
}
