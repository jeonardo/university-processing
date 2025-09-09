using FluentValidation;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Create;

public sealed class CreateDiplomaProcessRequestDtoValidator : AbstractValidator<CreateDiplomaProcessRequestDto>
{
    public CreateDiplomaProcessRequestDtoValidator()
    {
        RuleFor(x => x.PeriodId)
            .NotEmpty()
            .WithMessage("PeriodId is required");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
    }
}
