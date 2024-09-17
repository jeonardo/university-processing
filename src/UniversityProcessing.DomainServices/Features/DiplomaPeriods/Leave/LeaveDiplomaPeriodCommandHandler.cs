using MediatR;

namespace UniversityProcessing.DomainServices.Features.DiplomaPeriods.Leave;

internal sealed class LeaveDiplomaPeriodCommandHandler : IRequestHandler<LeaveDiplomaPeriodCommandRequest>
{
    public Task Handle(LeaveDiplomaPeriodCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
