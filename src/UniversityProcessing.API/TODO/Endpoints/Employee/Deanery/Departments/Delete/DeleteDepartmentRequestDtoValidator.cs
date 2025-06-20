using FluentValidation;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Deanery.Departments.Delete;

internal sealed class DeleteDepartmentRequestDtoValidator : AbstractValidator<DeleteDepartmentRequestDto>
{
    public DeleteDepartmentRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
