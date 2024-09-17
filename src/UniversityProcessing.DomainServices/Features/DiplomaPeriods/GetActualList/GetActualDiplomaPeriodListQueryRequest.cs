using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualList;

public sealed record GetActualDiplomaPeriodListQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetActualDiplomaPeriodListQueryResponse>;
