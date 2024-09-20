using MediatR;

namespace UniversityProcessing.DomainServices.Features.Specialties.Delete;

public sealed record DeleteSpecialtyCommandRequest(Guid Id) : IRequest;
