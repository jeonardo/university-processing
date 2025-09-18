using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Delete;

public sealed class RequestDto
{
    [Required]
    public Guid Id { get; set; }
}
