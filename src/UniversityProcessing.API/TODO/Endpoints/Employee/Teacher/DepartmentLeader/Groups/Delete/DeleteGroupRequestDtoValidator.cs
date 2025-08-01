using FluentValidation;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Delete;

public sealed class DeleteGroupRequestDtoValidator : AbstractValidator<DeleteGroupRequestDto>
{
    public DeleteGroupRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
