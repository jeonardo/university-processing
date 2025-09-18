using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Groups.Get;

public sealed class RequestDto : BaseGetListQueryParameters
{
    [Required]
    public Guid PeriodId { get; set; }
}
