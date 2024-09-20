using UniversityProcessing.Abstractions.Http.Universities.User;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Users.GetList;

public sealed record GetUsersQueryResponse(PagedList<UserDto> List);
