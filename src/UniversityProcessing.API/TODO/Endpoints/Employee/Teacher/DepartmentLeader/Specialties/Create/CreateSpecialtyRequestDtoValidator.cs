using FluentValidation;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Validation;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Specialties.Create;

public sealed class CreateSpecialtyRequestDtoValidator : AbstractValidator<CreateSpecialtyRequestDto>
{
    public CreateSpecialtyRequestDtoValidator(IEfReadRepository<Department> departmentRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("ShortName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.DepartmentId)
            .MustAsync((x, cancellationToken) => departmentRepository.AnyAsync(new GetByIdSpec<Department>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.DepartmentId.HasValue)
            .WithMessage("Faculty not found");

        RuleFor(x => x.Code)
            .Length(Specialty.CODE_LENGTH)
            .WithMessage($"Code is required. Length must be {Specialty.CODE_LENGTH} characters long");
    }
}
