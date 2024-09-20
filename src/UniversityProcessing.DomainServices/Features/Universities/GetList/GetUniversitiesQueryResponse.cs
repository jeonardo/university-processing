using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Universities.GetList;

public sealed record GetUniversitiesQueryResponse(PagedList<UniversityDto> List);
