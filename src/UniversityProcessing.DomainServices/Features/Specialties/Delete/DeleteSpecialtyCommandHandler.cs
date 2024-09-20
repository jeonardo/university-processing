using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Specialties.Delete;

internal sealed class DeleteSpecialtyCommandHandler(IEfRepository<Specialty> repository) : IRequestHandler<DeleteSpecialtyCommandRequest>
{
    public async Task Handle(DeleteSpecialtyCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(record, cancellationToken);
    }
}
