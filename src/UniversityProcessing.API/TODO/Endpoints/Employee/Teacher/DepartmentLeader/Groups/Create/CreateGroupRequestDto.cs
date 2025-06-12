using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Create;

public sealed class CreateGroupRequestDto
{
    [Required]
    public string GroupNumber { get; set; } = string.Empty;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public Guid SpecialtyId { get; set; }
}
