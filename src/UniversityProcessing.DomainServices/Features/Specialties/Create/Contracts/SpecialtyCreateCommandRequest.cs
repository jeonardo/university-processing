using MediatR;

namespace UniversityProcessing.DomainServices.Features.Specialties.Create.Contracts;

public sealed record SpecialtyCreateCommandRequest(string Name, string ShortName, string Code, Guid FacultyId) : IRequest<SpecialtyCreateCommandResponse>;