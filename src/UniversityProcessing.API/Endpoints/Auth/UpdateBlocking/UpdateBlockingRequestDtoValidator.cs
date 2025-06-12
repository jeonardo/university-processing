using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Auth.UpdateBlocking;

public sealed class UpdateBlockingRequestDtoValidator : AbstractValidator<UpdateBlockingRequestDto>
{
    public UpdateBlockingRequestDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}
