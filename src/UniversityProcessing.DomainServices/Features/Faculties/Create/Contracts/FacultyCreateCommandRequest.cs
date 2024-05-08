using MediatR;

namespace UniversityProcessing.DomainServices.Features.Faculties.Create.Contracts;

public sealed record FacultyCreateCommandRequest(string Name, string ShortName, Guid UniversityId)
    : IRequest<FacultyCreateCommandResponse>;