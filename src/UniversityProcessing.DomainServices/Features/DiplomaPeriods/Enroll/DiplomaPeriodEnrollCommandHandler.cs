using MediatR;
using Microsoft.AspNetCore.Identity;
using UniversityProcessing.Domain.Identity;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.DiplomaPeriods.Enroll.Contracts;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Enroll;

internal sealed class DiplomaPeriodEnrollCommandHandler(
    IEfRepository<DiplomaPeriod> diplomaPeriodRepository,
    UserManager<User> userManager)
    : IRequestHandler<DiplomaPeriodEnrollCommandRequest>
{
    public async Task Handle(DiplomaPeriodEnrollCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString())
            ?? throw new NotFoundException($"User with id = {request.UserId} not found");

        var diplomaPeriod = await diplomaPeriodRepository.GetByIdRequiredAsync(request.DiplomaPeriodId, cancellationToken);

        if (diplomaPeriod.Users.FirstOrDefault(x => x.Id == user.Id) is not null)
        {
            return;
        }

        diplomaPeriod.Users.Add(user);

        var resultCode = await diplomaPeriodRepository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(DiplomaPeriodEnrollCommandRequest)} failed");
        }
    }
}
