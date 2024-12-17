namespace UniversityProcessing.API.Endpoints.Registration.Employee.GetAvailableUniversityPositions;

public sealed class GetAvailableUniversityPositionsResponseDto(UniversityPositionDto[] list)
{
    public UniversityPositionDto[] List { get; set; } = list;
}
