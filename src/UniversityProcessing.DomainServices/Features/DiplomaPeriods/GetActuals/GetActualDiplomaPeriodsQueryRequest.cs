using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.GetActuals;

public sealed record GetActualDiplomaPeriodsQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetActualDiplomaPeriodsQueryResponse>;
