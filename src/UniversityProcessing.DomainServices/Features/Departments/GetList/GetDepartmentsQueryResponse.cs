using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;

namespace UniversityProcessing.DomainServices.Features.Departments.GetList;

public sealed record GetDepartmentsQueryResponse(PagedList<Department> List);
