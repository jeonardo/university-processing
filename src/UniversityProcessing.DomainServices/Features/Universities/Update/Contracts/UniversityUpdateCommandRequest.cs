using MediatR;

namespace UniversityProcessing.DomainServices.Features.Universities.Update.Contracts;

public sealed record UniversityUpdateCommandRequest : IRequest<UniversityUpdateCommandResponse>
{
}