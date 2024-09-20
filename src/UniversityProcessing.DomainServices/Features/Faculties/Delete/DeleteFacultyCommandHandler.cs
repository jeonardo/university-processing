using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Faculties.Delete;

internal sealed class DeleteFacultyCommandHandler(IEfRepository<Faculty> repository) : IRequestHandler<DeleteFacultyCommandRequest>
{
    public async Task Handle(DeleteFacultyCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(record, cancellationToken);
    }
}
