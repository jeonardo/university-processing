using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Departments.SetDepartmentHead;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
    {
        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .WithMessage("Department is required");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User is required");
    }
}
