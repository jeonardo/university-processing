namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class GetUniversityResponseDto
{
    public UniversityDto University { get; set; }

    public GetUniversityResponseDto(UniversityDto university)
    {
        University = university;
    }
}
