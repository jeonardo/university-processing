using UniversityProcessing.Abstractions.Http.Universities.Faculty;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Faculties.List.Contracts;

public sealed record FacultyListQueryResponse(PagedList<FacultyDto> List);