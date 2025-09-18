using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Faculties.GetFullDescription;

public sealed class RequestDtoValidator : AbstractValidator<RequestDto>
{
    public RequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
