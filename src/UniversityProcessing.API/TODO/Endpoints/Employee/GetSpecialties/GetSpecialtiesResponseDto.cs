using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.GetSpecialties;

public sealed class GetSpecialtiesResponseDto(PagedList<SpecialtyDto> list)
{
    public PagedList<SpecialtyDto> List { get; set; } = list;
}
