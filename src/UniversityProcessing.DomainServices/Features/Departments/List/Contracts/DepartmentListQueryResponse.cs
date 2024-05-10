using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Abstractions.Http.Universities.Department;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Departments.List.Contracts;

public sealed record DepartmentListQueryResponse(PagedList<DepartmentDto> List);