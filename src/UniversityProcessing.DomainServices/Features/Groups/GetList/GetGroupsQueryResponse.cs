using UniversityProcessing.Abstractions.Http.Universities.Group;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Groups.GetList;

public sealed record GetGroupsQueryResponse(PagedList<GroupDto> List);
