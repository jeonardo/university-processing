using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetStudents;

public sealed class RequestDto : BaseGetListQueryParameters
{
    [Required]
    public long PeriodId { get; set; }

    public long? GroupId { get; set; }
}
