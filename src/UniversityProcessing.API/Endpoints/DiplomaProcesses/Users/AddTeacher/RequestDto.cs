using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Users.AddTeacher;

public sealed class RequestDto
{
    [Required]
    public Guid DiplomaProcessId { get; set; }

    [Required]
    public Guid UserId { get; set; }
}
