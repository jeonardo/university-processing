using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Users.UpdateVerification;

public sealed class UpdateVerificationRequestDtoValidator : AbstractValidator<UpdateVerificationRequestDto>
{
    public UpdateVerificationRequestDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}
