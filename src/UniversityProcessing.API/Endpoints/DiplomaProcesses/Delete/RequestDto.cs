using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Delete;

public sealed class RequestDto
{
    [Required]
    public long Id { get; set; }
}
