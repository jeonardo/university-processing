using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.Universities.List.Contracts;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Universities.List;

public sealed class UniversityListQueryHandler(IEfReadRepository<University> repository)
    : IRequestHandler<UniversityListQueryRequest, UniversityListQueryResponse>
{
    public async Task<UniversityListQueryResponse> Handle(UniversityListQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new UniversityListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var records = await repository.ListAsync(specification, cancellationToken);

        return new UniversityListQueryResponse(UniversityConverter.ToPagedDto(records, count, request.PageNumber, request.PageSize));
    }
}