namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class UniversityPositionGetResponseDto(UniversityPositionDto department)
{
    public UniversityPositionDto UniversityPosition { get; set; } = department;
}