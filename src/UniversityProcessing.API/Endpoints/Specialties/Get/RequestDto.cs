using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Specialties.Get;

public sealed class RequestDto : BaseGetListQueryParameters
{
    [Required]
    public long DepartmentId { get; set; }
}
