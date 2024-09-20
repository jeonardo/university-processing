using MediatR;
using UniversityProcessing.Abstractions.Http.Converters;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;
using UniversityProcessing.Repository.Specifications;

namespace UniversityProcessing.DomainServices.Features.Groups.GetList;

internal sealed class GetGroupsQueryHandler(IEfReadRepository<Group> repository)
    : IRequestHandler<GetGroupsQueryRequest, GetGroupsQueryResponse>
{
    public async Task<GetGroupsQueryResponse> Handle(GetGroupsQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await repository.CountAsync(cancellationToken);

        var specification = new GroupListSpec(request.PageNumber, request.PageSize, request.OrderBy, request.Desc);
        var records = await repository.ListAsync(specification, cancellationToken);

        return new GetGroupsQueryResponse(GroupConverter.ToPagedDto(records, count, request.PageNumber, request.PageSize));
    }
}
