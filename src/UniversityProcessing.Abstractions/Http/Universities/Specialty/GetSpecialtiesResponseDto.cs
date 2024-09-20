using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class GetSpecialtiesResponseDto(PagedList<SpecialtyDto> list)
{
    public PagedList<SpecialtyDto> List { get; set; } = list;
}
