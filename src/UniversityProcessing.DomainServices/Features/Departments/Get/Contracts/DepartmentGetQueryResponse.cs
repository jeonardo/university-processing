using UniversityProcessing.Abstractions.Http.Universities;

namespace UniversityProcessing.DomainServices.Features.Departments.Get.Contracts;

public sealed record DepartmentGetQueryResponse(DepartmentDto Department);