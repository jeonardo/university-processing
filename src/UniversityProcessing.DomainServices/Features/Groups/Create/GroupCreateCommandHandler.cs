using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Groups.Create.Contracts;
using UniversityProcessing.GenericSubdomain.Middlewares.Exceptions;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Groups.Create;

internal sealed class GroupCreateCommandHandler(
    IEfRepository<Specialty> specialtyRepository,
    IEfRepository<Group> groupRepository)
    : IRequestHandler<GroupCreateCommandRequest, GroupCreateCommandResponse>
{
    public async Task<GroupCreateCommandResponse> Handle(GroupCreateCommandRequest request, CancellationToken cancellationToken)
    {
        var specialty = await specialtyRepository.GetByIdRequiredAsync(request.SpecialtyId, cancellationToken);

        var newEntity = new Group(request.GroupNumber, request.StartDate, request.EndDate, specialty);

        await groupRepository.AddAsync(newEntity, cancellationToken);

        var resultCode = await groupRepository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(GroupCreateCommandRequest)} failed");
        }

        return new GroupCreateCommandResponse(newEntity.Id);
    }
}
