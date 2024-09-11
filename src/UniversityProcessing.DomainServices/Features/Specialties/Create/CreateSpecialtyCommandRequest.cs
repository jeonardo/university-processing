using MediatR;

namespace UniversityProcessing.DomainServices.Features.Specialties.Create;

public sealed record CreateSpecialtyCommandRequest(string Name, string ShortName, string Code, Guid? FacultyId = null) : IRequest<CreateSpecialtyCommandResponse>;
