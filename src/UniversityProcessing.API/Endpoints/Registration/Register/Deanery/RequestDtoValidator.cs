using FluentValidation;
using Microsoft.Extensions.Options;
using UniversityProcessing.Infrastructure.Options;

namespace UniversityProcessing.API.Endpoints.Registration.Register.Deanery;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator(IOptions<IdentitySettings> options)
    {
        Include(new BaseRequestDtoValidator(options));

        RuleFor(x => x.UniversityPositionId)
            .NotEmpty()
            .WithMessage("UniversityPosition is required");

        RuleFor(x => x.FacultyId)
            .NotEmpty()
            .WithMessage("Faculty is required");
    }
}
