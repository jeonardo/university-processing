using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Universities.GetList;

public sealed record GetUniversitiesQueryResponse(PagedList<University> List);
