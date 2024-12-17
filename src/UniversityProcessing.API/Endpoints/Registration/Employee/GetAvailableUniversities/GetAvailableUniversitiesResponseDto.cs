namespace UniversityProcessing.API.Endpoints.Registration.Employee.GetAvailableUniversities;

public sealed class GetAvailableUniversitiesResponseDto(UniversityDto[] list)
{
    public UniversityDto[] List { get; set; } = list;
}
