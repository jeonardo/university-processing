using MediatR;

namespace UniversityProcessing.DomainServices.Features.Departments.Delete;

public sealed record DeleteDepartmentCommandRequest(Guid Id) : IRequest;
