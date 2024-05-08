using MediatR;

namespace UniversityProcessing.DomainServices.Features.UniversityPositions.List.Contracts;

public sealed record UniversityPositionListQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<UniversityPositionListQueryResponse>;