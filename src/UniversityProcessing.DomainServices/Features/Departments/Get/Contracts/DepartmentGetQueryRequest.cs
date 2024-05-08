using MediatR;

namespace UniversityProcessing.DomainServices.Features.Departments.Get.Contracts;

public sealed record DepartmentGetQueryRequest(Guid Id) : IRequest<DepartmentGetQueryResponse>;