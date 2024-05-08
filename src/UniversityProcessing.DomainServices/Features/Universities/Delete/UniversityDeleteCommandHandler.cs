using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Universities.Delete.Contracts;

namespace UniversityProcessing.DomainServices.Features.Universities.Delete;

internal sealed class UniversityDeleteCommandHandler(IRepository<University> repository) : IRequestHandler<UniversityDeleteCommandRequest>
{
    public async Task Handle(UniversityDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(University)} with id = {request.Id} not found");

        await repository.DeleteAsync(record, cancellationToken);
    }
}