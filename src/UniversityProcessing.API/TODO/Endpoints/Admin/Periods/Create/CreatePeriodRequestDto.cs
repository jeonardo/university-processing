using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Validation;

namespace UniversityProcessing.API.TODO.Endpoints.Admin.Periods.Create;

public sealed class CreatePeriodRequestDto
{
    [Required]
    public DateTime From { get; private set; }

    [Required]
    public DateTime To { get; private set; }

    [StringLength(ValidationConstants.MAX_STRING_LENGTH)]
    public string? Comments { get; private set; }
}
