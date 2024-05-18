using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Departments.List.Contracts;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Departments.List;

internal sealed class DepartmentListQueryHandler(IEfReadRepository<Department> repository)
    : IRequestHandler<DepartmentListQueryRequest, DepartmentListQueryResponse>
{
    public async Task<DepartmentListQueryResponse> Handle(DepartmentListQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new DepartmentListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var records = await repository.ListAsync(specification, cancellationToken);

        return new DepartmentListQueryResponse(DepartmentConverter.ToPagedDto(records, count, request.PageNumber, request.PageSize));
    }
}