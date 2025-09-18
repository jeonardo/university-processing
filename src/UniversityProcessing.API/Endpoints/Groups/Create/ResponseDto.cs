using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Groups.Create;

public sealed class ResponseDto(Guid id)
{
    [Required]
    public Guid Id { get; set; } = id;
}
