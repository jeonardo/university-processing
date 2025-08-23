namespace UniversityProcessing.API.Endpoints.Auth.Registration.GetAvailableFaculties;

public sealed class GetAvailableFacultiesResponseDto(FacultyDto[] faculties)
{
    public FacultyDto[] Faculties { get; set; } = faculties;
}
