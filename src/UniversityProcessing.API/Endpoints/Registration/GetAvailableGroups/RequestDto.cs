using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.GetAvailableGroups;

public sealed class RequestDto
{
    [Required]
    public string Number { get; set; } = string.Empty;
}
