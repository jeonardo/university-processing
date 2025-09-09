using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.DiplomaProcesses.Get;

public sealed class GetDiplomaProcessesRequestDto : BaseGetListQueryParameters
{
    [Required]
    public Guid PeriodId { get; set; }
}
