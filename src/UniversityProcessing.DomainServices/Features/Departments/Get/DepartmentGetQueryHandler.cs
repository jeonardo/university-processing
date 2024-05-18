using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Departments.Get.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Departments.Get;

internal sealed class DepartmentGetQueryHandler(IEfReadRepository<Department> repository)
    : IRequestHandler<DepartmentGetQueryRequest, DepartmentGetQueryResponse>
{
    public async Task<DepartmentGetQueryResponse> Handle(DepartmentGetQueryRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new DepartmentGetQueryResponse(DepartmentConverter.ToDto(record));
    }
}