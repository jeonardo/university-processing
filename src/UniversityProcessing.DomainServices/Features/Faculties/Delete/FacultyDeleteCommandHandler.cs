using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Faculties.Delete.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Faculties.Delete;

internal sealed class FacultyDeleteCommandHandler(IEfRepository<Faculty> repository) : IRequestHandler<FacultyDeleteCommandRequest>
{
    public async Task Handle(FacultyDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(record, cancellationToken);
    }
}