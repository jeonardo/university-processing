using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Departments.Delete;

public sealed class DeleteDepartmentRequestDtoValidator : AbstractValidator<DeleteDepartmentRequestDto>
{
    public DeleteDepartmentRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
