using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Exceptions;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.Groups.Get.Contracts;

namespace UniversityProcessing.DomainServices.Features.Groups.Get;

internal sealed class GroupGetQueryHandler(IReadRepository<Group> repository)
    : IRequestHandler<GroupGetQueryRequest, GroupGetQueryResponse>
{
    public async Task<GroupGetQueryResponse> Handle(
        GroupGetQueryRequest request,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"{nameof(Group)} with id = {request.Id} not found");

        return new GroupGetQueryResponse(GroupConverter.ToDto(record));
    }
}