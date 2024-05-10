using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Universities.Delete.Contracts;
using UniversityProcessing.GenericSubdomain.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Universities.Delete;

internal sealed class UniversityDeleteCommandHandler(IEfRepository<University> repository) : IRequestHandler<UniversityDeleteCommandRequest>
{
    public async Task Handle(UniversityDeleteCommandRequest request, CancellationToken cancellationToken)
    {
var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(record, cancellationToken);
    }
}