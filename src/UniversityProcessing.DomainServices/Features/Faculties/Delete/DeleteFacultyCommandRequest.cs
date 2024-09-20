using MediatR;

namespace UniversityProcessing.DomainServices.Features.Faculties.Delete;

public sealed record DeleteFacultyCommandRequest(Guid Id) : IRequest;
