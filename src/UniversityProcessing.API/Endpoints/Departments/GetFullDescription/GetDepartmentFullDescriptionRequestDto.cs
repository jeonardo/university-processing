using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Departments.GetFullDescription;

public sealed class GetDepartmentFullDescriptionRequestDto
{
    [Required]
    public Guid Id { get; set; }
}
