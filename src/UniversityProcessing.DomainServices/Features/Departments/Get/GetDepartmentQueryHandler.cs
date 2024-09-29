using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Departments.Get;

internal sealed class GetDepartmentQueryHandler(IEfReadRepository<Department> repository)
    : IRequestHandler<GetDepartmentQueryRequest, GetDepartmentQueryResponse>
{
    public async Task<GetDepartmentQueryResponse> Handle(GetDepartmentQueryRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);
        return new GetDepartmentQueryResponse(entity);
    }
}
