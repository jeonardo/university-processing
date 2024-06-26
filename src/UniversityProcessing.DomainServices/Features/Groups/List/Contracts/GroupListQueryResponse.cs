using UniversityProcessing.Abstractions.Http.Universities.Group;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Groups.List.Contracts;

public sealed record GroupListQueryResponse(PagedList<GroupDto> List);