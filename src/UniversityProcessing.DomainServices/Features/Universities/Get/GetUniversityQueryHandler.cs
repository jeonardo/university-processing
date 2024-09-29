using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Universities.Get;

public sealed class GetUniversityQueryHandler(IEfReadRepository<University> repository)
    : IRequestHandler<GetUniversityQueryRequest, GetUniversityQueryResponse>
{
    public async Task<GetUniversityQueryResponse> Handle(
        GetUniversityQueryRequest request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        return new GetUniversityQueryResponse(entity);
    }
}
