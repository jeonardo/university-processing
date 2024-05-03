using MediatR;
using UniversityProcessing.DomainServices.Features.Universities.Remove.Contracts;

namespace UniversityProcessing.DomainServices.Features.Universities.Remove;

internal sealed class UniversityRemoveCommandHandler
    : IRequestHandler<UniversityRemoveCommandRequest, UniversityRemoveCommandResponse>
{
    public Task<UniversityRemoveCommandResponse> Handle(
        UniversityRemoveCommandRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}