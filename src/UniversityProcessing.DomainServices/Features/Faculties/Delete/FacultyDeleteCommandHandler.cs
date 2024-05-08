using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Faculties.Delete.Contracts;

namespace UniversityProcessing.DomainServices.Features.Faculties.Delete;

internal sealed class FacultyDeleteCommandHandler(IRepository<Faculty> repository) : IRequestHandler<FacultyDeleteCommandRequest>
{
    public async Task Handle(FacultyDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Faculty)} with id = {request.Id} not found");

        await repository.DeleteAsync(record, cancellationToken);
    }
}