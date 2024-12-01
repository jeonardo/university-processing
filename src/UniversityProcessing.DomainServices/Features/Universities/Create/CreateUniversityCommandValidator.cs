using FluentValidation;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Universities.Create;

public sealed class CreateUniversityCommandValidator : AbstractValidator<CreateUniversityCommandRequest>
{
    public CreateUniversityCommandValidator(IEfReadRepository<User> userRepository)
    {
        RuleFor(x => x.AdminId)
            .MustAsync((x, cancellationToken) => userRepository.AnyAsync(new GetByIdSpec<User>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.AdminId.HasValue)
            .WithMessage("User not found");
    }
}
