using FluentValidation;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Universities.ChangeUniversityAdmin;

internal sealed class ChangeUniversityAdminCommandValidator : AbstractValidator<ChangeUniversityAdminCommandRequest>
{
    public ChangeUniversityAdminCommandValidator(IEfReadRepository<User> userRepository)
    {
        RuleFor(x => x.UserId)
            .MustAsync((x, cancellationToken) => userRepository.AnyAsync(new GetByIdSpec<User>(x), cancellationToken))
            .WithMessage("User not found");
    }
}
