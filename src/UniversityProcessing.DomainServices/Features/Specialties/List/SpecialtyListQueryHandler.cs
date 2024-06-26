using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Specialties.List.Contracts;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Specialties.List;

internal sealed class SpecialtyListQueryHandler(IEfReadRepository<Specialty> repository)
    : IRequestHandler<SpecialtyListQueryRequest, SpecialtyListQueryResponse>
{
    public async Task<SpecialtyListQueryResponse> Handle(SpecialtyListQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new SpecialtyListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var records = await repository.ListAsync(specification, cancellationToken);

        return new SpecialtyListQueryResponse(SpecialtyConverter.ToPagedDto(records, count, request.PageNumber, request.PageSize));
    }
}