namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class GetUniversityResponseDto(UniversityDto university)
{
    public UniversityDto University { get; set; } = university;
}
