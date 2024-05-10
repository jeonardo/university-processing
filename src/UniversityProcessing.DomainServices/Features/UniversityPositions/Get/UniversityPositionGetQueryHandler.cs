using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.UniversityPositions.Get.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.UniversityPositions.Get;

internal sealed class UniversityPositionGetQueryHandler(IEfRepository<UniversityPosition> repository)
    : IRequestHandler<UniversityPositionGetQueryRequest, UniversityPositionGetQueryResponse>
{
    public async Task<UniversityPositionGetQueryResponse> Handle(UniversityPositionGetQueryRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new UniversityPositionGetQueryResponse(UniversityPositionConverter.ToDto(record));
    }
}