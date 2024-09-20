using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.Delete;

public sealed record DeleteUniversityCommandRequest(Guid Id) : IRequest;
