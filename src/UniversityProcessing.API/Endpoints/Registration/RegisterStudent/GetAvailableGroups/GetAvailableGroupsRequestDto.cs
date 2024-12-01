using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Registration.RegisterStudent.GetAvailableGroups;

public sealed class GetAvailableGroupsRequestDto
{
    [Required]
    public string Number { get; set; } = string.Empty;
}
