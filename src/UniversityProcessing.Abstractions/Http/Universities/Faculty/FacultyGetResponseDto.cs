namespace UniversityProcessing.Abstractions.Http.Universities.Faculty;

public sealed class FacultyGetResponseDto(FacultyDto department)
{
    public FacultyDto Faculty { get; set; } = department;
}