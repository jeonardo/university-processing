namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class UniversityGetResponseDto
{
    public UniversityDto University { get; set; }

    public UniversityGetResponseDto(UniversityDto university)
    {
        University = university;
    }
}