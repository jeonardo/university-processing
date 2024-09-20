using UniversityProcessing.Abstractions.Http.Universities.Department;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Departments.GetList;

public sealed record GetDepartmentsQueryResponse(PagedList<DepartmentDto> List);
