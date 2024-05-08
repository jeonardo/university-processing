using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.Departments.Get.Contracts;

namespace UniversityProcessing.DomainServices.Features.Departments.Get;

internal sealed class DepartmentGetQueryHandler(IReadRepository<Department> repository) : IRequestHandler<DepartmentGetQueryRequest, DepartmentGetQueryResponse>
{
    public async Task<DepartmentGetQueryResponse> Handle(DepartmentGetQueryRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Department)} with id = {request.Id} not found");

        return new DepartmentGetQueryResponse(DepartmentConverter.ToDto(record));
    }
}