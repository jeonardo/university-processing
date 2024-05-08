using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Groups.Delete.Contracts;

namespace UniversityProcessing.DomainServices.Features.Groups.Delete;

internal sealed class GroupDeleteCommandHandler(IRepository<Group> repository) : IRequestHandler<GroupDeleteCommandRequest>
{
    public async Task Handle(GroupDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Group)} with id = {request.Id} not found");

        await repository.DeleteAsync(record, cancellationToken);
    }
}