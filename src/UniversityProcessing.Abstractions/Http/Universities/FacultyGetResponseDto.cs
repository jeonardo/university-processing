namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class FacultyGetResponseDto(FacultyDto department)
{
    public FacultyDto Faculty { get; set; } = department;
}