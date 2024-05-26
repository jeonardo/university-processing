using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Groups.Get.Contracts;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Groups.Get;

internal sealed class GroupGetQueryHandler(IEfReadRepository<Group> repository)
    : IRequestHandler<GroupGetQueryRequest, GroupGetQueryResponse>
{
    public async Task<GroupGetQueryResponse> Handle(
        GroupGetQueryRequest request,
        CancellationToken cancellationToken)
    {
        var record = await repository.GetByIdRequiredAsync(request.Id, cancellationToken);

        return new GroupGetQueryResponse(GroupConverter.ToDto(record));
    }
}