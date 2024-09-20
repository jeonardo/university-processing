using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.UniversityPositions.Get;

internal sealed class GetUniversityPositionQueryHandler(IEfRepository<UniversityPosition> repository)
    : IRequestHandler<GetUniversityPositionQueryRequest, GetUniversityPositionQueryResponse>
{
    public async Task<GetUniversityPositionQueryResponse> Handle(GetUniversityPositionQueryRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new GetUniversityPositionQueryResponse(UniversityPositionConverter.ToDto(record));
    }
}
