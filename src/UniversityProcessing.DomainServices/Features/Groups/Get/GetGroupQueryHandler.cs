using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Groups.Get;

internal sealed class GetGroupQueryHandler(IEfReadRepository<Group> repository)
    : IRequestHandler<GetGroupQueryRequest, GetGroupQueryResponse>
{
    public async Task<GetGroupQueryResponse> Handle(
        GetGroupQueryRequest request,
        CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        return new GetGroupQueryResponse(entity);
    }
}
