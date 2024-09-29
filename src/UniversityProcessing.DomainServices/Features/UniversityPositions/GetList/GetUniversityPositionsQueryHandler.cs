using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.UniversityPositions.GetList;

internal sealed class GetUniversityPositionsQueryHandler(IEfReadRepository<UniversityPosition> repository)
    : IRequestHandler<GetUniversityPositionsQueryRequest, GetUniversityPositionsQueryResponse>
{
    public async Task<GetUniversityPositionsQueryResponse> Handle(GetUniversityPositionsQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new UniversityPositionListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetUniversityPositionsQueryResponse(new PagedList<UniversityPosition>(entities, count, request.PageNumber, request.PageSize));
    }
}
