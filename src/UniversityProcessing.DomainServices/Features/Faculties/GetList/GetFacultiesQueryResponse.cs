using UniversityProcessing.Abstractions.Http.Universities.Faculty;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Faculties.GetList;

public sealed record GetFacultiesQueryResponse(PagedList<FacultyDto> List);
