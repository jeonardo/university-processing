using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
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
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new GetUniversityQueryResponse(UniversityConverter.ToDto(record));
    }
}
