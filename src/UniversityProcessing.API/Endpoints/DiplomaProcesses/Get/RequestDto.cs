using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Get;

public sealed class RequestDto : BaseGetListQueryParameters
{
    [Required]
    public long PeriodId { get; set; }
}
