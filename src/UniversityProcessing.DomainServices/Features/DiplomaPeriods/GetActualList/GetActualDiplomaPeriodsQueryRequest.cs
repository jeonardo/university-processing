using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActualList;

public sealed record GetActualDiplomaPeriodsQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetActualDiplomaPeriodsQueryResponse>;
