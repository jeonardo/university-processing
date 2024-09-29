using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Pagination;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Departments.GetList;

internal sealed class GetDepartmentsQueryHandler(IEfReadRepository<Department> repository)
    : IRequestHandler<GetDepartmentsQueryRequest, GetDepartmentsQueryResponse>
{
    public async Task<GetDepartmentsQueryResponse> Handle(GetDepartmentsQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new DepartmentListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var entities = await repository.ListAsync(specification, cancellationToken);

        return new GetDepartmentsQueryResponse(new PagedList<Department>(entities, count, request.PageNumber, request.PageSize));
    }
}
