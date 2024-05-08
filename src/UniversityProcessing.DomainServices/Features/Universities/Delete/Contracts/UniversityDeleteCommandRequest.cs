using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.Delete.Contracts;

public sealed record UniversityDeleteCommandRequest(Guid Id) : IRequest;