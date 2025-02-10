using FluentValidation;
using UniversityProcessing.GenericSubdomain.Validation;

namespace UniversityProcessing.API.Endpoints.Registration.Student.GetAvailableGroups;

public sealed class GetAvailableGroupsRequestDtoValidator : AbstractValidator<GetAvailableGroupsRequestDto>
{
    public GetAvailableGroupsRequestDtoValidator()
    {
        RuleFor(x => x.Number)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Number is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);
    }
}
