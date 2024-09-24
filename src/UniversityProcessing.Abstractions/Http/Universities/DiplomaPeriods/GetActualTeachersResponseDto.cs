using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.Abstractions.Http.Universities.DiplomaPeriods;

public sealed class GetActualTeachersResponseDto(PagedList<TeacherDto> list)
{
    public PagedList<TeacherDto> List { get; set; } = list;
}
