using MediatR;

namespace UniversityProcessing.DomainServices.Features.Identity.Delete;

public sealed record DeleteUserCommandRequest(Guid Id) : IRequest;
