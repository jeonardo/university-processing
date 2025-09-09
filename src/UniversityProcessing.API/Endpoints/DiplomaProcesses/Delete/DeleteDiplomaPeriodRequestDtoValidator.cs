using FluentValidation;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Delete;

public sealed class DeleteDiplomaPeriodRequestDtoValidator : AbstractValidator<DeleteDiplomaPeriodRequestDto>
{
    public DeleteDiplomaPeriodRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
