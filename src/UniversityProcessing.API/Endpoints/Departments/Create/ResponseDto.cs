using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Departments.Create;

public sealed class ResponseDto(long id)
{
    [Required]
    public long Id { get; set; } = id;
}
