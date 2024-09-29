using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Abstractions.Http.Identity.RegisterStudent;

public sealed class GetRegisterStudentAvailableGroupsRequestDto
{
    [Required]
    public string Number { get; set; } = string.Empty;
}
