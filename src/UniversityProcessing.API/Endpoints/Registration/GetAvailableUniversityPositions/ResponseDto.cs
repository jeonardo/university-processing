namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableUniversityPositions;

public sealed class ResponseDto(UniversityPositionDto[] list)
{
    public UniversityPositionDto[] List { get; set; } = list;
}
