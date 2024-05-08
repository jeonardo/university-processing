using MediatR;

namespace UniversityProcessing.DomainServices.Features.Faculties.Delete.Contracts;

public sealed record FacultyDeleteCommandRequest(Guid Id) : IRequest;