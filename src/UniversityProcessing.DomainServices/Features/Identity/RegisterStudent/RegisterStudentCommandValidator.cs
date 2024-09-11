using FluentValidation;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterStudent;

internal sealed class RegisterStudentCommandValidator : AbstractValidator<RegisterStudentCommandRequest>
{
    public RegisterStudentCommandValidator(IEfReadRepository<Group> groupRepository)
    {
        RuleFor(x => x.GroupId)
            .MustAsync((x, cancellationToken) => groupRepository.AnyAsync(new GetByIdSpec<Group>(x.GetValueOrDefault()), cancellationToken))
            .When(x => x.GroupId.HasValue)
            .WithMessage("Group not found");
    }
}
