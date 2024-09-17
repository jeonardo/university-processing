using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Departments.Delete;

internal sealed class DeleteDepartmentCommandHandler(IEfRepository<Department> repository) : IRequestHandler<DeleteDepartmentCommandRequest>
{
    public async Task Handle(DeleteDepartmentCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(entity, cancellationToken);
    }
}
