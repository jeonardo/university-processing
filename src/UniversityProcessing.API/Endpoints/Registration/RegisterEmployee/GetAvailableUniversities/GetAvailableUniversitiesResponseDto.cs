namespace UniversityProcessing.API.Endpoints.Registration.RegisterEmployee.GetAvailableUniversities;

public sealed class GetAvailableUniversitiesResponseDto(UniversityDto[] list)
{
    public UniversityDto[] List { get; set; } = list;
}
