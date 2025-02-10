using FluentValidation;
using UniversityProcessing.Domain;
using UniversityProcessing.GenericSubdomain.Validation;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Create;

public sealed class CreateGroupRequestDtoValidator : AbstractValidator<CreateGroupRequestDto>
{
    public CreateGroupRequestDtoValidator(IEfReadRepository<Specialty> specialtyRepository)
    {
        RuleFor(x => x.GroupNumber)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("GroupNumber is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.SpecialtyId)
            .MustAsync((x, cancellationToken) => specialtyRepository.AnyAsync(new GetByIdSpec<Specialty>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.SpecialtyId.HasValue)
            .WithMessage("Specialty not found");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("StartDate is required");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("EndDate is required");
    }
}
