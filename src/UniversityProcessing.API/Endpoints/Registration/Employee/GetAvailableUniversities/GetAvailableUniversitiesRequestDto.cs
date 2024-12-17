using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.Employee.GetAvailableUniversities;

public sealed class GetAvailableUniversitiesRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
