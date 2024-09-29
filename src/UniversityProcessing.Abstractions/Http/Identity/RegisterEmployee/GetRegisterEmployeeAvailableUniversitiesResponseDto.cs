namespace UniversityProcessing.Abstractions.Http.Identity.RegisterEmployee;

public sealed class GetRegisterEmployeeAvailableUniversitiesResponseDto(RegisterEmployeeUniversityDto[] list)
{
    public RegisterEmployeeUniversityDto[] List { get; set; } = list;
}
