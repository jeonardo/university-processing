using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Domain.Validation;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Admin.Departments.Create;

public sealed class CreateDepartmentRequestDtoValidator : AbstractValidator<CreateDepartmentRequestDto>
{
    public CreateDepartmentRequestDtoValidator(IEfReadRepository<Faculty> facultyRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("ShortName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.FacultyId)
            .MustAsync((x, cancellationToken) => facultyRepository.AnyAsync(new GetByIdSpec<Faculty>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.FacultyId.HasValue)
            .WithMessage("Faculty not found");
    }
}
