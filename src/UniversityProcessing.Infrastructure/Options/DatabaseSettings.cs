using System.ComponentModel.DataAnnotations;

namespace UniversityProcessing.Infrastructure.Options;

public sealed class DatabaseSettings
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;

    [Required]
    public string SqliteConnectionString { get; set; } = string.Empty;
}
