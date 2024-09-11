using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterEmployee;

internal sealed class RegisterEmployeeCommandValidator : AbstractValidator<RegisterEmployeeCommandRequest>
{
    public RegisterEmployeeCommandValidator(IEfReadRepository<University> universityRepository, IEfReadRepository<UniversityPosition> universityPositionRepository)
    {
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
