using MediatR;

namespace UniversityProcessing.DomainServices.Features.Departments.Get;

public sealed record GetDepartmentQueryRequest(Guid Id) : IRequest<GetDepartmentQueryResponse>;
