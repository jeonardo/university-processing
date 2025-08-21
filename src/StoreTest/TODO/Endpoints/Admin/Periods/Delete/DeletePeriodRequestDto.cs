using System.ComponentModel.DataAnnotations;

namespace StoreTest.TODO.Endpoints.Admin.Periods.Delete;

public sealed class DeletePeriodRequestDto
{
    [Required]
    public Guid Id { get; set; }
}
