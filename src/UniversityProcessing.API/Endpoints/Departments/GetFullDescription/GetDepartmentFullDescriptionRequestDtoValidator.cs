using FluentValidation;

namespace UniversityProcessing.API.Endpoints.Departments.GetFullDescription;

public sealed class GetDepartmentFullDescriptionRequestDtoValidator : AbstractValidator<GetDepartmentFullDescriptionRequestDto>
{
    public GetDepartmentFullDescriptionRequestDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");
    }
}
