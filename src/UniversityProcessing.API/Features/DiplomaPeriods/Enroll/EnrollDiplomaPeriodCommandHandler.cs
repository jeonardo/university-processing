using MediatR;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Features.DiplomaPeriods.Enroll;

internal sealed class EnrollDiplomaPeriodCommandHandler(
    IEfRepository<DiplomaPeriod> diplomaPeriodRepository,
    IEfReadRepository<User> userRepository,
    ILogger<EnrollDiplomaPeriodCommandHandler> logger)
    : IRequestHandler<EnrollDiplomaPeriodCommandRequest>
{
    public async Task Handle(EnrollDiplomaPeriodCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdRequiredAsync(request.UserId, cancellationToken);

        var diplomaPeriod = await diplomaPeriodRepository.GetByIdRequiredAsync(request.DiplomaPeriodId, cancellationToken);

        if (diplomaPeriod.Users.Any(x => x.Id == user.Id))
        {
            logger.LogWarning(
                "{EnrollDiplomaPeriodCommandRequestName} failed. User {UserId} is already enrolled in {DiplomaPeriodId}",
                nameof(EnrollDiplomaPeriodCommandRequest),
                user.Id,
                diplomaPeriod.Id);
            return;
        }

        diplomaPeriod.Users.Add(user);

        var resultCode = await diplomaPeriodRepository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(EnrollDiplomaPeriodCommandRequest)} failed");
        }
    }
}
