using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Departments.Delete.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Departments.Delete;

internal sealed class DepartmentDeleteCommandHandler(IEfRepository<Department> repository) : IRequestHandler<DepartmentDeleteCommandRequest>
{
    public async Task Handle(DepartmentDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(record, cancellationToken);
    }
}