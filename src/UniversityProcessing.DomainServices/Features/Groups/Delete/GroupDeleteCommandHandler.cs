using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Groups.Delete.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Groups.Delete;

internal sealed class GroupDeleteCommandHandler(IEfRepository<Group> repository) : IRequestHandler<GroupDeleteCommandRequest>
{
    public async Task Handle(GroupDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        await repository.DeleteAsync(record, cancellationToken);
    }
}