using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Groups.Create;

internal sealed class CreateGroupCommandHandler(IEfRepository<Group> groupRepository)
    : IRequestHandler<CreateGroupCommandRequest, CreateGroupCommandResponse>
{
    public async Task<CreateGroupCommandResponse> Handle(CreateGroupCommandRequest request, CancellationToken cancellationToken)
    {
        var newEntity = Group.Create(request.GroupNumber, request.StartDate, request.EndDate, request.SpecialtyId);

        await groupRepository.AddAsync(newEntity, cancellationToken);

        return new CreateGroupCommandResponse(newEntity.Id);
    }
}
