namespace UniversityProcessing.Abstractions.Http.Identity.RegisterEmployee;

public sealed class GetRegisterEmployeeAvailableUniversityPositionsResponseDto(RegisterEmployeeUniversityPositionDto[] list)
{
    public RegisterEmployeeUniversityPositionDto[] List { get; set; } = list;
}
