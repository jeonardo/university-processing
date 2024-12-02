using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Admin.Groups.Delete;

public sealed class DeleteGroupRequestDto
{
    [Required]
    public Guid Id { get; set; }
}
