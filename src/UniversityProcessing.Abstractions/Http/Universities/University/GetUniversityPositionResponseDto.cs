namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class GetUniversityPositionResponseDto(UniversityPositionDto department)
{
    public UniversityPositionDto UniversityPosition { get; set; } = department;
}
