using UniversityProcessing.Abstractions.Http.Universities.Specialty;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Specialties.GetList;

public sealed record GetSpecialtiesQueryResponse(PagedList<SpecialtyDto> List);
