using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Create;

public sealed class CreateDiplomaPeriodRequestDtoValidator : AbstractValidator<CreateDiplomaPeriodRequestDto>
{
    public CreateDiplomaPeriodRequestDtoValidator()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("StartDate is required");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("EndDate is required");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
    }
}
