using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.API.Endpoints.Periods.Get;

public sealed class PeriodDto(Guid id, string name, DateTime from, DateTime to, string? comments)
{
    [Required]
    public Guid Id { get; set; } = id;

    [Required]
    public string Name { get; set; } = name;

    [Required]
    public DateTime From { get; set; } = from;

    [Required]
    public DateTime To { get; set; } = to;

    public string? Comments { get; set; } = comments;
}
