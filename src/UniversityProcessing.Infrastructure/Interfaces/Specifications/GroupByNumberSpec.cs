using Ardalis.Specification;
using UniversityProcessing.Domain;

namespace UniversityProcessing.Infrastructure.Interfaces.Specifications;

public sealed class GroupByNumberSpec : Specification<Group>
{
    public GroupByNumberSpec(string number)
    {
        Query
            .AsNoTracking()
            .Where(x => x.Number == number);
    }
}
