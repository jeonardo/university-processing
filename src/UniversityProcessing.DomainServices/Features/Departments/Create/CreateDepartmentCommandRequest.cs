using MediatR;

namespace UniversityProcessing.DomainServices.Features.Departments.Create;

public sealed record CreateDepartmentCommandRequest(string Name, string ShortName, Guid? FacultyId = null) : IRequest<CreateDepartmentCommandResponse>;
