using MediatR;
using UniversityProcessing.Abstractions.Http.Universities.Diploma;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActual.Contracts;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActual;

internal sealed class DiplomaPeriodGetActualQueryHandler(IEfReadRepository<DiplomaPeriod> repository)
    : IRequestHandler<DiplomaPeriodGetActualQueryRequest, DiplomaPeriodGetActualQueryResponse>
{
    public async Task<DiplomaPeriodGetActualQueryResponse> Handle(DiplomaPeriodGetActualQueryRequest request, CancellationToken cancellationToken)
    {
        //var spec = new DiplomaPeriodActualListSpec();
        var record = await repository.ListAsync();

        // return new DiplomaPeriodGetActualQueryResponse(DiplomaPeriodConverter.ToDto(record));
        return new DiplomaPeriodGetActualQueryResponse(new PagedList<DiplomaPeriodDto>([], 0, 0, 0));
    }
}
