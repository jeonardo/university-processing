using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Specialties.Delete.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Specialties.Delete;

internal sealed class SpecialtyDeleteCommandHandler(IEfRepository<Specialty> repository) : IRequestHandler<SpecialtyDeleteCommandRequest>
{
    public async Task Handle(SpecialtyDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(record, cancellationToken);
    }
}