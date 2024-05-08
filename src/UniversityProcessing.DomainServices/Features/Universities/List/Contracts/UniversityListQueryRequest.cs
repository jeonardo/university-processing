using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.List.Contracts;

public sealed record UniversityListQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<UniversityListQueryResponse>;