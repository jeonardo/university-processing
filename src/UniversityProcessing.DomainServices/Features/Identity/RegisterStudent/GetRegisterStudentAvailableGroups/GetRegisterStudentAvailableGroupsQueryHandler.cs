using Ardalis.Specification;
using MediatR;
using UniversityProcessing.Domain.UniversityStructure;
using UniversityProcessing.Repository.Repositories;

namespace UniversityProcessing.DomainServices.Features.Identity.RegisterStudent.GetRegisterStudentAvailableGroups;

internal sealed class GetRegisterStudentAvailableGroupsQueryHandler(IEfReadRepository<Group> repository)
    : IRequestHandler<GetRegisterStudentAvailableGroupsQueryRequest, GetRegisterStudentAvailableGroupsQueryResponse>
{
    public async Task<GetRegisterStudentAvailableGroupsQueryResponse> Handle(GetRegisterStudentAvailableGroupsQueryRequest request, CancellationToken cancellationToken)
    {
        var specification = new GetRegisterStudentAvailableGroupsSpecification(request.Number);
        var groups = await repository.ListAsync(specification, cancellationToken);
        return new GetRegisterStudentAvailableGroupsQueryResponse(groups.ToArray());
    }

    private sealed class GetRegisterStudentAvailableGroupsSpecification : Specification<Group, string>
    {
        public GetRegisterStudentAvailableGroupsSpecification(string number)
        {
            Query
                .Select(x => x.Number)
                .AsNoTracking()
                .Where(x => x.Number.Contains(number) || x.Number.Contains(number))
                .Take(10);
        }
    }
}
