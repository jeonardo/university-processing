using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Departments.Delete;

internal sealed class DeleteDepartmentRequestDtoValidator : AbstractValidator<DeleteDepartmentRequestDto>
{
    public DeleteDepartmentRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
