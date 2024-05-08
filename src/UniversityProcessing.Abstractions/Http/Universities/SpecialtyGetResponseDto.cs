namespace UniversityProcessing.Abstractions.Http.Universities;

public sealed class SpecialtyGetResponseDto(SpecialtyDto department)
{
    public SpecialtyDto Specialty { get; set; } = department;
}