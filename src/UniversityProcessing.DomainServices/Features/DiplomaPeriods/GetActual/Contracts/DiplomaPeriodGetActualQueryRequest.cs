using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActual.Contracts;

public sealed record DiplomaPeriodGetActualQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<DiplomaPeriodGetActualQueryResponse>;
