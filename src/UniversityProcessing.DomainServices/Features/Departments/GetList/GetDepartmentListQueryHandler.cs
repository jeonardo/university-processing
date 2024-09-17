using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Departments.GetList;

internal sealed class GetDepartmentListQueryHandler(IEfReadRepository<Department> repository)
    : IRequestHandler<GetDepartmentListQueryRequest, GetDepartmentListQueryResponse>
{
    public async Task<GetDepartmentListQueryResponse> Handle(GetDepartmentListQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new DepartmentListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var records = await repository.ListAsync(specification, cancellationToken);

        return new GetDepartmentListQueryResponse(DepartmentConverter.ToPagedDto(records, count, request.PageNumber, request.PageSize));
    }
}
