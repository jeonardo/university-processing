using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Universities.Delete;

internal sealed class DeleteUniversityCommandHandler(IEfRepository<University> repository) : IRequestHandler<DeleteUniversityCommandRequest>
{
    public async Task Handle(DeleteUniversityCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(record, cancellationToken);
    }
}
