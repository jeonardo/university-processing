using MediatR;
using UniversityProcessing.DomainServices.Features.Universities.Update.Contracts;

namespace UniversityProcessing.DomainServices.Features.Universities.Update;

internal sealed class UniversityUpdateCommandHandler
    : IRequestHandler<UniversityUpdateCommandRequest, UniversityUpdateCommandResponse>
{
    public Task<UniversityUpdateCommandResponse> Handle(
        UniversityUpdateCommandRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}