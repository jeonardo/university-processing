using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.DiplomaProcesses.Delete;

public sealed class DeleteDiplomaPeriodRequestDtoValidator : AbstractValidator<DeleteDiplomaPeriodRequestDto>
{
    public DeleteDiplomaPeriodRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
