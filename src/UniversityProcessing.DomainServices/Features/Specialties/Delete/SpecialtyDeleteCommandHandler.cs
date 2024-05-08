using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Specialties.Delete.Contracts;

namespace UniversityProcessing.DomainServices.Features.Specialties.Delete;

internal sealed class SpecialtyDeleteCommandHandler(IRepository<Specialty> repository) : IRequestHandler<SpecialtyDeleteCommandRequest>
{
    public async Task Handle(SpecialtyDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Specialty)} with id = {request.Id} not found");

        await repository.DeleteAsync(record, cancellationToken);
    }
}