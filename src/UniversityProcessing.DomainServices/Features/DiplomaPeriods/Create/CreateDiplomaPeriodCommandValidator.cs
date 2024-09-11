using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Create;

internal sealed class CreateDiplomaPeriodCommandValidator : AbstractValidator<CreateDiplomaPeriodCommandRequest>
{
    public CreateDiplomaPeriodCommandValidator(IEfReadRepository<DiplomaPeriod> diplomaPeriodRepository)
    {
        RuleFor(x => x.FacultyId)
            .MustAsync((x, cancellationToken) => diplomaPeriodRepository.AnyAsync(new GetByIdSpec<DiplomaPeriod>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.FacultyId.HasValue)
            .WithMessage("Diploma period already exists");
    }
}
