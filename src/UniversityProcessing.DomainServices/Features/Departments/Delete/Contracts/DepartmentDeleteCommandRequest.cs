using MediatR;

namespace UniversityProcessing.DomainServices.Features.Departments.Delete.Contracts;

public sealed record DepartmentDeleteCommandRequest(Guid Id) : IRequest;