using FluentValidation;
using UniversityProcessing.Domain.Validation;

namespace UniversityProcessing.API.Endpoints.Registration.RegisterStudent.GetAvailableGroups;

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
