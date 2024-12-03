using MediatR;

namespace UniversityProcessing.API.Features.DiplomaPeriods.GetActuals;

public sealed record GetActualDiplomaPeriodsQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetActualDiplomaPeriodsQueryResponse>;
