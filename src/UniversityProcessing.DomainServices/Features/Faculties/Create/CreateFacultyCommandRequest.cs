using MediatR;

namespace UniversityProcessing.DomainServices.Features.Faculties.Create;

public sealed record CreateFacultyCommandRequest(string Name, string ShortName, Guid? UniversityId = null)
    : IRequest<CreateFacultyCommandResponse>;
