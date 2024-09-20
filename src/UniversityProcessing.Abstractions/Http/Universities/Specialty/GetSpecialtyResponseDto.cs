namespace UniversityProcessing.Abstractions.Http.Universities.Specialty;

public sealed class GetSpecialtyResponseDto(SpecialtyDto department)
{
    public SpecialtyDto Specialty { get; set; } = department;
}
