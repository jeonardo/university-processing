using MediatR;

namespace UniversityProcessing.DomainServices.Features.Specialties.Delete.Contracts;

public sealed record SpecialtyDeleteCommandRequest(Guid Id) : IRequest;