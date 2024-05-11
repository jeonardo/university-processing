using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Universities.Create.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Universities.Create;

internal sealed class UniversityCreateCommandHandler(IEfRepository<University> repository)
    : IRequestHandler<UniversityCreateCommandRequest, UniversityCreateCommandResponse>
{
    public async Task<UniversityCreateCommandResponse> Handle(
        UniversityCreateCommandRequest request,
        CancellationToken cancellationToken)
    {
        var newEntity = new University(request.Name, request.ShortName);
        var createdEntity = await repository.AddAsync(newEntity, cancellationToken);
        return new UniversityCreateCommandResponse(createdEntity.Id);
    }
}