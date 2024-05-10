using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Abstractions.Http.Universities.University;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Universities.List.Contracts;

public sealed record UniversityListQueryResponse(PagedList<UniversityDto> List);