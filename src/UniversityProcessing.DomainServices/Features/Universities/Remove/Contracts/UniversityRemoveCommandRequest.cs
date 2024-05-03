using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.Remove.Contracts;

public sealed record UniversityRemoveCommandRequest : IRequest<UniversityRemoveCommandResponse>;