using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Domain.Validation;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.API.Endpoints.Admin.Faculties.Create;

public sealed class CreateFacultyRequestDtoValidator : AbstractValidator<CreateFacultyRequestDto>
{
    public CreateFacultyRequestDtoValidator(IEfReadRepository<University> universityRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("Name is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.ShortName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MAX_STRING_LENGTH)
            .WithMessage("ShortName is required. Max length = " + ValidationConstants.MAX_STRING_LENGTH);

        RuleFor(x => x.UniversityId)
            .MustAsync((x, cancellationToken) => universityRepository.AnyAsync(new GetByIdSpec<University>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.UniversityId.HasValue)
            .WithMessage("University not found");
    }
}
