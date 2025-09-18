using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Departments.Delete;

public sealed class RequestDto
{
    [Required]
    public Guid Id { get; set; }
}
