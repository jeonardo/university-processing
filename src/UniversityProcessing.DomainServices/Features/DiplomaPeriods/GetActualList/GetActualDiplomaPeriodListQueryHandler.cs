using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualList;

internal sealed class GetActualDiplomaPeriodListQueryHandler(IEfReadRepository<DiplomaPeriod> repository)
    : IRequestHandler<GetActualDiplomaPeriodListQueryRequest, GetActualDiplomaPeriodListQueryResponse>
{
    public IEfReadRepository<DiplomaPeriod> Repository { get; } = repository;

    public Task<GetActualDiplomaPeriodListQueryResponse> Handle(GetActualDiplomaPeriodListQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //var spec = new DiplomaPeriodActualListSpec();
        // var record = await repository.ListAsync();
        //
        // // return new DiplomaPeriodGetActualQueryResponse(DiplomaPeriodConverter.ToDto(record));
        // return new GetActualListDiplomaPeriodQueryResponse(new PagedList<DiplomaPeriodDto>([], 0, 0, 0));
    }
}
