namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableFaculties;

public sealed class ResponseDto(FacultyDto[] faculties)
{
    public FacultyDto[] Faculties { get; set; } = faculties;
}
