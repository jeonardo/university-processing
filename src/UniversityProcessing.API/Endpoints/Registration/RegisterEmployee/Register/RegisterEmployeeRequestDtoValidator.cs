using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Domain.Validation;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Registration.RegisterEmployee.Register;

public sealed class RegisterEmployeeRequestDtoValidator : AbstractValidator<RegisterEmployeeRequestDto>
{
    public RegisterEmployeeRequestDtoValidator(IEfReadRepository<University> universityRepository, IEfReadRepository<UniversityPosition> universityPositionRepository)
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Username is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Password is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("First name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Last name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Email must be valid. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.MiddleName)
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("MiddleName must be valid. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.UniversityId)
            .MustAsync((x, cancellationToken) => universityRepository.AnyAsync(new GetByIdSpec<University>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.UniversityId.HasValue)
            .WithMessage("University not found");

        RuleFor(x => x.UniversityPositionId)
            .MustAsync((x, cancellationToken) => universityPositionRepository.AnyAsync(new GetByIdSpec<UniversityPosition>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.UniversityPositionId.HasValue)
            .WithMessage("University position not found");
    }
}
