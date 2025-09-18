using FluentValidation;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Create;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
    {
        RuleFor(x => x.PeriodId)
            .NotEmpty()
            .WithMessage("PeriodId is required");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
    }
}
