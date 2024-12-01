using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Admin.Users.UpdateApproval;

public sealed class UpdateApprovalRequestDtoValidator : AbstractValidator<UpdateApprovalRequestDto>
{
    public UpdateApprovalRequestDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");
    }
}
