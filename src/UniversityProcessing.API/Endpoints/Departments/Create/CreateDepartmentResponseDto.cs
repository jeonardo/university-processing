using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Departments.Create;

public sealed class CreateDepartmentResponseDto(Guid id)
{
    [Required]
    public Guid Id { get; set; } = id;
}
