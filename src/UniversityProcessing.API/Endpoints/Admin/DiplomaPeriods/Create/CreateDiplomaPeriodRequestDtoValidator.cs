using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Admin.DiplomaPeriods.Create;

public sealed class CreateDiplomaPeriodRequestDtoValidator : AbstractValidator<CreateDiplomaPeriodRequestDto>
{
    public CreateDiplomaPeriodRequestDtoValidator(IEfReadRepository<DiplomaPeriod> diplomaPeriodRepository)
    {
        RuleFor(x => x.FacultyId)
            .MustAsync((x, cancellationToken) => diplomaPeriodRepository.AnyAsync(new GetByIdSpec<DiplomaPeriod>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.FacultyId.HasValue)
            .WithMessage("Faculty not found");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("StartDate is required");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("EndDate is required");
    }
}
