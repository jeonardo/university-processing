using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.API.Endpoints.Common.GetSpecialties;

public sealed class GetSpecialtiesResponseDto(PagedList<SpecialtyDto> list)
{
    public PagedList<SpecialtyDto> List { get; set; } = list;
}
