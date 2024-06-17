using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Users.List.Contracts;

public sealed record UserListQueryResponse(PagedList<UserDto> List);
