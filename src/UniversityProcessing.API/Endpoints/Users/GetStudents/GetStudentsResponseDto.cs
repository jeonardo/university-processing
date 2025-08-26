using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetStudents;

public sealed class GetStudentsResponseDto(PagedList<StudentDto> list)
{
    public PagedList<StudentDto> List { get; set; } = list;
}
