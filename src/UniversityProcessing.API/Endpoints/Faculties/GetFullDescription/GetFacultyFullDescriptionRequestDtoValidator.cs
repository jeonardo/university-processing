using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Faculties.GetFullDescription;

public sealed class GetFacultyFullDescriptionRequestDtoValidator : AbstractValidator<GetFacultyFullDescriptionRequestDto>
{
    public GetFacultyFullDescriptionRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
