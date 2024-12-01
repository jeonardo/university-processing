using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Faculties.Create;

public sealed class CreateFacultyCommandValidator : AbstractValidator<CreateFacultyCommandRequest>
{
    public CreateFacultyCommandValidator(IEfReadRepository<University> universityRepository)
    {
        RuleFor(x => x.UniversityId)
            .MustAsync((x, cancellationToken) => universityRepository.AnyAsync(new GetByIdSpec<University>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.UniversityId.HasValue)
            .WithMessage("University not found");
    }
}
