using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Specialties.Delete;

public sealed class DeleteSpecialtyRequestDto
{
    [Required]
    public Guid Id { get; set; }
}
