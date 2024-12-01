using FluentValidation;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Admin.Universities.ChangeAdmin;

public sealed class ChangeUniversityAdminRequestDtoValidator : AbstractValidator<ChangeUniversityAdminRequestDto>
{
    public ChangeUniversityAdminRequestDtoValidator(IEfReadRepository<User> userRepository)
    {
        RuleFor(x => x.UserId)
            .MustAsync((x, cancellationToken) => userRepository.AnyAsync(new GetByIdSpec<User>(x), cancellationToken))
            .WithMessage("User not found");
    }
}
