using MediatR;

namespace UniversityProcessing.DomainServices.Features.Users.List.Contracts;

public sealed record UserListQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<UserListQueryResponse>;