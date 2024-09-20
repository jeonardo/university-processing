namespace UniversityProcessing.Abstractions.Http.Universities.Faculty;

public sealed class GetFacultyResponseDto(FacultyDto department)
{
    public FacultyDto Faculty { get; set; } = department;
}
