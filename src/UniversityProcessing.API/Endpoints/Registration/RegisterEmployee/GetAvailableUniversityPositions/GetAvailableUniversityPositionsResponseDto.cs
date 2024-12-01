namespace UniversityProcessing.API.Endpoints.Registration.RegisterEmployee.GetAvailableUniversityPositions;

public sealed class GetAvailableUniversityPositionsResponseDto(UniversityPositionDto[] list)
{
    public UniversityPositionDto[] List { get; set; } = list;
}
