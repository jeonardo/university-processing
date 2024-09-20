using MediatR;

namespace UniversityProcessing.DomainServices.Features.Groups.GetList;

public sealed record GetGroupsQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetGroupsQueryResponse>;
