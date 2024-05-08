using MediatR;

namespace UniversityProcessing.DomainServices.Features.Groups.List.Contracts;

public sealed record GroupListQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GroupListQueryResponse>;