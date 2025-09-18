using FluentValidation;
using Microsoft.Extensions.Options;
using UniversityProcessing.Infrastructure.Options;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.Endpoints.Registration.Register.Student;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator(IOptions<IdentitySettings> options)
    {
        Include(new BaseRequestDtoValidator(options));

        RuleFor(x => x.GroupNumber)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("GroupNumber is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
