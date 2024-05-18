using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Faculties.List.Contracts;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Faculties.List;

internal sealed class FacultyListQueryHandler(IEfReadRepository<Faculty> repository)
    : IRequestHandler<FacultyListQueryRequest, FacultyListQueryResponse>
{
    public async Task<FacultyListQueryResponse> Handle(FacultyListQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new FacultyListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var records = await repository.ListAsync(specification, cancellationToken);

        return new FacultyListQueryResponse(FacultyConverter.ToPagedDto(records, count, request.PageNumber, request.PageSize));
    }
}