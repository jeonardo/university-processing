using FluentValidation;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.Validation;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Admin.Universities.Create;

public sealed class CreateUniversityRequestDtoValidator : AbstractValidator<CreateUniversityRequestDto>
{
    public CreateUniversityRequestDtoValidator(IEfReadRepository<User> userRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("ShortName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.AdminId)
            .MustAsync((x, cancellationToken) => userRepository.AnyAsync(new GetByIdSpec<User>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.AdminId.HasValue)
            .WithMessage("User not found");
    }
}
