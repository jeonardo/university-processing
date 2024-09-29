using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Groups.GetList;

public sealed record GetGroupsQueryResponse(PagedList<Group> List);
