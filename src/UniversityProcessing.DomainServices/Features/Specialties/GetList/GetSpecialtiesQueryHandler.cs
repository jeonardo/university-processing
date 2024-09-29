using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Specialties.GetList;

internal sealed class GetSpecialtiesQueryHandler(IEfReadRepository<Specialty> repository)
    : IRequestHandler<GetSpecialtiesQueryRequest, GetSpecialtiesQueryResponse>
{
    public async Task<GetSpecialtiesQueryResponse> Handle(GetSpecialtiesQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new SpecialtyListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetSpecialtiesQueryResponse(new PagedList<Specialty>(entities, count, request.PageNumber, request.PageSize));
    }
}
