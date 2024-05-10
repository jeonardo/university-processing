using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.Universities.Get.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Universities.Get;

public sealed class UniversityGetQueryHandler(IEfReadRepository<University> repository)
    : IRequestHandler<UniversityGetQueryRequest, UniversityGetQueryResponse>
{
    public async Task<UniversityGetQueryResponse> Handle(
        UniversityGetQueryRequest request,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new UniversityGetQueryResponse(UniversityConverter.ToDto(record));
    }
}