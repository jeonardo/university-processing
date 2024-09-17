using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Delete;

internal sealed class DeleteDiplomaPeriodCommandHandler(IEfRepository<DiplomaPeriod> repository) : IRequestHandler<DeleteDiplomaPeriodCommandRequest>
{
    public async Task Handle(DeleteDiplomaPeriodCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(entity, cancellationToken);
    }
}
