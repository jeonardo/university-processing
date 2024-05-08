using MediatR;

namespace UniversityProcessing.DomainServices.Features.Groups.Delete.Contracts;

public sealed record GroupDeleteCommandRequest(Guid Id) : IRequest;