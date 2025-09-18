using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Auth.Refresh;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotEmpty()
            .WithMessage("AccessToken is required");

        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("RefreshToken is required");
    }
}
