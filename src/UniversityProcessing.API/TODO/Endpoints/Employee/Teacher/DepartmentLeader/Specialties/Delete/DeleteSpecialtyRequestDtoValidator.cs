using FluentValidation;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Specialties.Delete;

public sealed class DeleteSpecialtyRequestDtoValidator : AbstractValidator<DeleteSpecialtyRequestDto>
{
    public DeleteSpecialtyRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
