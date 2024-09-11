using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Departments.Create;

internal sealed class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommandRequest>
{
    public CreateDepartmentCommandValidator(IEfReadRepository<Faculty> facultyRepository)
    {
        RuleFor(x => x.FacultyId)
            .MustAsync((x, cancellationToken) => facultyRepository.AnyAsync(new GetByIdSpec<Faculty>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.FacultyId.HasValue)
            .WithMessage("Faculty not found");
    }
}
