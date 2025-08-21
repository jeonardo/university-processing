using System.ComponentModel.DataAnnotations;

namespace StoreTest.TODO.Endpoints.Employee.Teacher.DepartmentLeader.Groups.Delete;

public sealed class DeleteGroupRequestDto
{
    [Required]
    public Guid Id { get; set; }
}
