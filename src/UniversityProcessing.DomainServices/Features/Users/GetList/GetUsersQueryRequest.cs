using MediatR;

namespace UniversityProcessing.DomainServices.Features.Users.GetList;

public sealed record GetUsersQueryRequest(
    int PageNumber,
    int PageSize,
    string OrderBy,
    bool Desc) : IRequest<GetUsersQueryResponse>;
