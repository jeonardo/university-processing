namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class SpecialtyGetResponseDto(SpecialtyDto department)
{
    public SpecialtyDto Specialty { get; set; } = department;
}