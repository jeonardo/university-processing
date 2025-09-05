using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Departments.SetDepartmentHead;

public sealed class SetDepartmentHeadRequestDtoValidator : AbstractValidator<SetDepartmentHeadRequestDto>
{
    public SetDepartmentHeadRequestDtoValidator()
    {
        RuleFor(x => x.DepartmentId)
            .NotEmpty()
            .WithMessage("Department is required");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User is required");
    }
}
