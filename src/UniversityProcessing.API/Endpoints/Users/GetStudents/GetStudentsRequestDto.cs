using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Users.GetStudents;

public sealed class GetStudentsRequestDto : BaseGetListQueryParameters
{
    [Required]
    public Guid PeriodId { get; set; }

    public Guid? GroupId { get; set; }
}
