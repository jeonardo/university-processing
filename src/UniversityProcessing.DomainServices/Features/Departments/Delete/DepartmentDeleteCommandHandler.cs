using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Departments.Delete.Contracts;

namespace UniversityProcessing.DomainServices.Features.Departments.Delete;

internal sealed class DepartmentDeleteCommandHandler(IRepository<Department> repository) : IRequestHandler<DepartmentDeleteCommandRequest>
{
    public async Task Handle(DepartmentDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Department)} with id = {request.Id} not found");

        await repository.DeleteAsync(record, cancellationToken);
    }
}