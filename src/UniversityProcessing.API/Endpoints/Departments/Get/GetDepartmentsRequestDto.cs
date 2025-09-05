using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Departments.Get;

public sealed class GetDepartmentsRequestDto : BaseGetListQueryParameters
{
    [Required]
    public Guid FacultyId { get; set; }
}
