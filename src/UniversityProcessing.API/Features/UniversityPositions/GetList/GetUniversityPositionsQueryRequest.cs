using MediatR;

namespace UniversityProcessing.API.Features.UniversityPositions.GetList;

public sealed record GetUniversityPositionsQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetUniversityPositionsQueryResponse>;
