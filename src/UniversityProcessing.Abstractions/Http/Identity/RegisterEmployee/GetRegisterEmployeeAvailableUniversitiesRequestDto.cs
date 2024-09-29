using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Identity.RegisterEmployee;

public sealed class GetRegisterEmployeeAvailableUniversitiesRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
