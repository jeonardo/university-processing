namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableUniversityPositions;

public sealed class UniversityPositionDto(long id, string name)
{
    public long Id { get; set; } = id;
    public string Name { get; set; } = name;
}
