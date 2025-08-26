using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetTeachers;

public sealed class GetTeachersResponseDto(PagedList<TeacherDto> list)
{
    public PagedList<TeacherDto> List { get; set; } = list;
}
