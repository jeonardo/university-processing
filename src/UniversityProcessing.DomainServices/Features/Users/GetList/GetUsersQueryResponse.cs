using UniversityProcessing.Domain.Identity;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Users.GetList;

public sealed record GetUsersQueryResponse(PagedList<User> List);
