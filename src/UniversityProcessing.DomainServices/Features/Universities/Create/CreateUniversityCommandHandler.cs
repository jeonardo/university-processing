using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Universities.Create;

internal sealed class CreateUniversityCommandHandler(IEfRepository<University> repository)
    : IRequestHandler<CreateUniversityCommandRequest, CreateUniversityCommandResponse>
{
    public async Task<CreateUniversityCommandResponse> Handle(CreateUniversityCommandRequest request, CancellationToken cancellationToken)
    {
        var newEntity = University.Create(request.Name, request.ShortName, request.AdminId);

        var createdEntity = await repository.AddAsync(newEntity, cancellationToken);

        return new CreateUniversityCommandResponse(createdEntity.Id);
    }
}
