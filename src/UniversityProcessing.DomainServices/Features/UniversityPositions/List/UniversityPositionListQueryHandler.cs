using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.UniversityPositions.List.Contracts;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.UniversityPositions.List;

internal sealed class UniversityPositionListQueryHandler(IEfReadRepository<UniversityPosition> repository)
    : IRequestHandler<UniversityPositionListQueryRequest, UniversityPositionListQueryResponse>
{
    public async Task<UniversityPositionListQueryResponse> Handle(UniversityPositionListQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new UniversityPositionListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var records = await repository.ListAsync(specification, cancellationToken);

        return new UniversityPositionListQueryResponse(UniversityPositionConverter.ToPagedDto(records, count, request.PageNumber, request.PageSize));
    }
}