using Ardalis.SharedKernel;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.DomainServices.Features.Converters;
using UniversityProcessing.DomainServices.Features.Groups.List.Contracts;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Groups.List;

internal sealed class GroupListQueryHandler(IReadRepository<Group> repository)
    : IRequestHandler<GroupListQueryRequest, GroupListQueryResponse>
{
    public async Task<GroupListQueryResponse> Handle(GroupListQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new GroupListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var records = await repository.ListAsync(specification, cancellationToken);

        return new GroupListQueryResponse(GroupConverter.ToPagedDto(records, count, request.PageNumber, request.PageSize));
    }
}