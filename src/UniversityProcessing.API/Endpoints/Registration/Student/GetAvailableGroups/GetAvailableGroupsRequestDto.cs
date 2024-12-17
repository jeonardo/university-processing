using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.Student.GetAvailableGroups;

public sealed class GetAvailableGroupsRequestDto
{
    [Required]
    public string Number { get; set; } = string.Empty;
}
