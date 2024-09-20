using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
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
        var records = await repository.ListAsync(specification, cancellationToken);

        return new GetUniversitiesQueryResponse(UniversityConverter.ToPagedDto(records, count, request.PageNumber, request.PageSize));
    }
}
