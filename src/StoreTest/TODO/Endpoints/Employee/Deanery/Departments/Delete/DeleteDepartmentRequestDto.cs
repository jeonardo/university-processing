using System.ComponentModel.DataAnnotations;

namespace StoreTest.TODO.Endpoints.Employee.Deanery.Departments.Delete;

public sealed class DeleteDepartmentRequestDto
{
    [Required]
    public Guid Id { get; set; }
}
