using System.ComponentModel.DataAnnotations;

namespace StoreTest.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Specialties.Delete;

public sealed class DeleteSpecialtyRequestDto
{
    [Required]
    public Guid Id { get; set; }
}
