using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Users.UpdateBlocking;

public sealed class UpdateBlockingRequestDtoValidator : AbstractValidator<UpdateBlockingRequestDto>
{
    public UpdateBlockingRequestDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}
