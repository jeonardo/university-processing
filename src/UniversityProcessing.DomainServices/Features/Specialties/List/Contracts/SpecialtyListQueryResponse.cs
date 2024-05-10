using UniversityProcessing.Abstractions.Http.Universities.Specialty;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Specialties.List.Contracts;

public sealed record SpecialtyListQueryResponse(PagedList<SpecialtyDto> List);