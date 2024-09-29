using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Universities.GetList;

public sealed class GetUniversitiesQueryHandler(IEfReadRepository<University> repository)
    : IRequestHandler<GetUniversitiesQueryRequest, GetUniversitiesQueryResponse>
{
    public async Task<GetUniversitiesQueryResponse> Handle(GetUniversitiesQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new UniversityListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetUniversitiesQueryResponse(new PagedList<University>(entities, count, request.PageNumber, request.PageSize));
    }
}
