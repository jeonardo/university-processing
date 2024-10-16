using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Specialties.Get;

internal sealed class GetSpecialtyQueryHandler(IEfReadRepository<Specialty> repository)
    : IRequestHandler<GetSpecialtyQueryRequest, GetSpecialtyQueryResponse>
{
    public async Task<GetSpecialtyQueryResponse> Handle(
        GetSpecialtyQueryRequest request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        return new GetSpecialtyQueryResponse(entity);
    }
}
