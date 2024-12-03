using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.API.Features.DiplomaPeriods.Get;

internal sealed class GetDiplomaPeriodQueryHandler(IEfReadRepository<DiplomaPeriod> repository)
    : IRequestHandler<GetDiplomaPeriodQueryRequest, GetDiplomaPeriodQueryResponse>
{
    public async Task<GetDiplomaPeriodQueryResponse> Handle(GetDiplomaPeriodQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        return new GetDiplomaPeriodQueryResponse(entity);
    }
}
