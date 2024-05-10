namespace UniversityProcessing.Abstractions.Http.Universities.University;

public sealed class UniversityGetResponseDto
{
    public UniversityDto University { get; set; }

    public UniversityGetResponseDto(UniversityDto university)
    {
        University = university;
    }
}