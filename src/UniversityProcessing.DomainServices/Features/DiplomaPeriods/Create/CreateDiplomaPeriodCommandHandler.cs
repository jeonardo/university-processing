using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Create;

internal sealed class CreateDiplomaPeriodCommandHandler(IEfRepository<DiplomaPeriod> diplomaPeriodRepository)
    : IRequestHandler<CreateDiplomaPeriodCommandRequest, CreateDiplomaPeriodCommandResponse>
{
    public async Task<CreateDiplomaPeriodCommandResponse> Handle(CreateDiplomaPeriodCommandRequest request, CancellationToken cancellationToken)
    {
        var newEntity = DiplomaPeriod.Create(request.StartDate, request.EndDate, request.FacultyId);

        await diplomaPeriodRepository.AddAsync(newEntity, cancellationToken);

        return new CreateDiplomaPeriodCommandResponse(newEntity.Id);
    }
}
