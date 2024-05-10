namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityPositionGetResponseDto(UniversityPositionDto department)
{
    public UniversityPositionDto UniversityPosition { get; set; } = department;
}