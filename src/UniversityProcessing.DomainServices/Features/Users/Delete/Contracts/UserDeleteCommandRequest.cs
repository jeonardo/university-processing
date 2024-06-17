using MediatR;

namespace UniversityProcessing.DomainServices.Features.Users.Delete.Contracts;

public sealed record UserDeleteCommandRequest(Guid Id) : IRequest;
