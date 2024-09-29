using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Faculties.GetList;

internal sealed class GetFacultiesQueryHandler(IEfReadRepository<Faculty> repository)
    : IRequestHandler<GetFacultiesQueryRequest, GetFacultiesQueryResponse>
{
    public async Task<GetFacultiesQueryResponse> Handle(GetFacultiesQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new FacultyListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetFacultiesQueryResponse(new PagedList<Faculty>(entities, count, request.PageNumber, request.PageSize));
    }
}
