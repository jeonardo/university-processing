using System.ComponentModel.DataAnnotations;

namespace StoreTest.Admin.Faculties.Delete;

public sealed class DeleteFacultyRequestDto
{
    [Required]
    public Guid Id { get; set; }
}
