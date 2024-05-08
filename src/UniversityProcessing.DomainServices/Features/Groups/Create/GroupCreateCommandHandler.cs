using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Groups.Create.Contracts;

namespace UniversityProcessing.DomainServices.Features.Groups.Create;

internal sealed class GroupCreateCommandHandler(
    IRepository<Specialty> specialtyRepository,
    IRepository<Group> groupRepository)
    : IRequestHandler<GroupCreateCommandRequest, GroupCreateCommandResponse>
{
    public async Task<GroupCreateCommandResponse> Handle(GroupCreateCommandRequest request, CancellationToken cancellationToken)
    {
        var specialty = await specialtyRepository.GetByIdAsync(request.SpecialtyId, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Specialty)} with id = {request.SpecialtyId} not found");

        var newEntity = new Group(request.GroupNumber, request.StartDate, request.EndDate, specialty, specialty.Faculty);

        await groupRepository.AddAsync(newEntity, cancellationToken);

        var resultCode = await groupRepository.SaveChangesAsync(cancellationToken);

        if (resultCode is not 1)
        {
            throw new ConflictException($"{nameof(GroupCreateCommandRequest)} failed");
        }

        return new GroupCreateCommandResponse(newEntity.Id);
    }
}