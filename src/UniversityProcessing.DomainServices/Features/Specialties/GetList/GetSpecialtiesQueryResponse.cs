using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Specialties.GetList;

public sealed record GetSpecialtiesQueryResponse(PagedList<Specialty> List);
