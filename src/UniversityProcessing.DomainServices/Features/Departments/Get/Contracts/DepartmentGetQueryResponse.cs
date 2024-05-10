using UniversityProcessing.Abstractions.Http.Universities;
using UniversityProcessing.Abstractions.Http.Universities.Department;

namespace UniversityProcessing.DomainServices.Features.Departments.Get.Contracts;

public sealed record DepartmentGetQueryResponse(DepartmentDto Department);