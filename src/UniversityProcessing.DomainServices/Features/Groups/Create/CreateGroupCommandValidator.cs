using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Groups.Create;

internal sealed class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommandRequest>
{
    public CreateGroupCommandValidator(IEfReadRepository<Specialty> specialtyRepository)
    {
        RuleFor(x => x.SpecialtyId)
            .MustAsync((x, cancellationToken) => specialtyRepository.AnyAsync(new GetByIdSpec<Specialty>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.SpecialtyId.HasValue)
            .WithMessage("Specialty not found");
    }
}
