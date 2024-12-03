using MediatR;

namespace UniversityProcessing.API.Features.DiplomaPeriods.Leave;

internal sealed class LeaveDiplomaPeriodCommandHandler : IRequestHandler<LeaveDiplomaPeriodCommandRequest>
{
    public Task Handle(LeaveDiplomaPeriodCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
