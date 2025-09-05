using System.ComponentModel.DataAnnotations;
using UniversityProcessing.Utils.Pagination;

namespace UniversityProcessing.API.Endpoints.Departments.Get;

public sealed class GetDepartmentsResponseDto([Required] PagedList<DepartmentDto> list) : PagedList<DepartmentDto>(list);
