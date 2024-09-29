using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Faculties.GetList;

public sealed record GetFacultiesQueryResponse(PagedList<Faculty> List);
