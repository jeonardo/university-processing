using MediatR;

namespace UniversityProcessing.DomainServices.Features.Departments.Create.Contracts;

public record DepartmentCreateCommandRequest(string Name, string ShortName, Guid FacultyId) : IRequest<DepartmentCreateCommandResponse>;