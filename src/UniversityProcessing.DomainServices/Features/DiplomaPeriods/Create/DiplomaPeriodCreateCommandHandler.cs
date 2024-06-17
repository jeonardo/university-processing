using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.DiplomaPeriods.Create.Contracts;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Create;

internal sealed class DiplomaPeriodCreateCommandHandler(
    IEfRepository<DiplomaPeriod> diplomaPeriodRepository,
    IEfRepository<Faculty> facultyRepository)
    : IRequestHandler<DiplomaPeriodCreateCommandRequest, DiplomaPeriodCreateCommandResponse>
{
    public async Task<DiplomaPeriodCreateCommandResponse> Handle(DiplomaPeriodCreateCommandRequest request, CancellationToken cancellationToken)
    {
        var faculty = await facultyRepository.GetByIdRequiredAsync(request.FacultyId, cancellationToken);

        var newEntity = new DiplomaPeriod(faculty, request.StartDate, request.EndDate);

        await diplomaPeriodRepository.AddAsync(newEntity, cancellationToken);

        var resultCode = await diplomaPeriodRepository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(DiplomaPeriodCreateCommandRequest)} failed");
        }

        return new DiplomaPeriodCreateCommandResponse(newEntity.Id);
    }
}
