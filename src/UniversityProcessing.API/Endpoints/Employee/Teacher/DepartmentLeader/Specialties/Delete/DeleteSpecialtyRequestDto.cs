using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Employee.Teacher.DepartmentLeader.Specialties.Delete;

public sealed class DeleteSpecialtyRequestDto
{
    [Required]
    public Guid Id { get; set; }
}
