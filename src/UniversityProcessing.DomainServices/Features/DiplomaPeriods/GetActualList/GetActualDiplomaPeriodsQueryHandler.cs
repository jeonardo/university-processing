using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualList;

internal sealed class GetActualDiplomaPeriodsQueryHandler(IEfReadRepository<DiplomaPeriod> repository)
    : IRequestHandler<GetActualDiplomaPeriodsQueryRequest, GetActualDiplomaPeriodsQueryResponse>
{
    public IEfReadRepository<DiplomaPeriod> Repository { get; } = repository;

    public Task<GetActualDiplomaPeriodsQueryResponse> Handle(GetActualDiplomaPeriodsQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        //var spec = new DiplomaPeriodActualListSpec();
        // var record = await repository.ListAsync();
        //
        // // return new DiplomaPeriodGetActualQueryResponse(DiplomaPeriodConverter.ToDto(record));
        // return new GetActualListDiplomaPeriodQueryResponse(new PagedList<DiplomaPeriodDto>([], 0, 0, 0));
    }
}
