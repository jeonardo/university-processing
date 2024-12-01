using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.Universities.Create;

public sealed class CreateUniversityRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string ShortName { get; set; } = string.Empty;

    public Guid? AdminId { get; set; }
}
