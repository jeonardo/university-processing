using Ardalis.Specification;
using UniversityProcessing.Domain;

namespace UniversityProcessing.API.Endpoints.Auth.Registration.Student.GetAvailableGroups;

internal sealed class GetAvailableGroupsSpecification : Specification<Group, string>
{
    public GetAvailableGroupsSpecification(string number)
    {
        Query
            .Select(x => x.Number)
            .AsNoTracking()
            .Where(x => x.Number.Contains(number) || x.Number.Contains(number))
            .Take(10);
    }
}
